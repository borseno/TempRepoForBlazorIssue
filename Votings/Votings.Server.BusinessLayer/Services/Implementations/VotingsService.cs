using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;
using Votings.Server.DAL;
using Votings.Server.DAL.Models;
using Votings.Shared;
using Votings.Shared.DTO;
using Votings.Shared.PageModels;
using Votings.Shared.PageResults;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class VotingsService : IVotingsService
    {
        private readonly VotingsDbContext ctx;
        private readonly IMapper mapper;

        public VotingsService(VotingsDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<VotingReference>> GetVotingsReferencesAsync(bool currentUserOnly, string userId)
        {
            var votings = currentUserOnly
                ? ctx.Votings.AsQueryable()
                : ctx.Votings.Where(i => i.AuthorId == userId);

            var result = await votings
                .AsNoTracking()
                .ProjectTo<VotingReference>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            return result;
        }

        public async Task<VotingRegisteringResult> Register(VotingInitialInfoModel model, string userId, int? votingId)
        {
            var errors = model.GetValidationErrors();

            if (errors != null && errors.Count() > 0)
            {
                return new VotingRegisteringResult
                {
                    Errors = errors
                };
            }

            var options = model.Options
                .Select(i => new Option
                {
                    Id = Guid.NewGuid(),
                    Description = i,
                    VotingId = votingId != null ? votingId.Value : default
                })
                .ToArray();

            var voting = mapper.Map<Voting>(model);

            voting.Options = options;
            voting.AuthorId = userId;

            int resultId;

            if (votingId != null)
            {
                var entity = await ctx.Votings
                    .FirstAsync(i => i.Id == votingId);

                ctx.Options.RemoveRange(await ctx.Options.Where(i => i.VotingId == votingId).ToArrayAsync());
                ctx.Options.AddRange(voting.Options);
                
                #region not_important

                entity.Description = voting.Description;
                entity.StartDate = voting.StartDate;
                entity.DueDate = voting.DueDate;
                entity.IsAnonymous = voting.IsAnonymous;
                entity.IsClosed = voting.IsClosed;
                entity.IsLimited = voting.IsLimited;
                entity.MaxChoicesAmount = voting.MaxChoicesAmount;
                entity.MinChoicesAmount = voting.MinChoicesAmount;
                entity.Name = voting.Name;

                #endregion not_important

                resultId = votingId.Value;
              
                await ctx.SaveChangesAsync();
            }
            else
            {
                var entry = ctx.Votings.Add(voting);
                await ctx.SaveChangesAsync();

                resultId = entry.Entity.Id; 
            }            

            var result = ResultBase.SuccessfulResult<VotingRegisteringResult>();
            result.VotingId = resultId;

            return result;
        }

        public async Task<VotingState> GetVotingStateAsync(int votingId, string userId)
        {
            var votingInfo = await ctx.Votings
                .Include(i => i.Options)
                    .ThenInclude(j => j.Choices)
                        .ThenInclude(k => k.Option)
                .FirstOrDefaultAsync(i => i.Id == votingId); // perf critical query, should be optimized            

            if (votingInfo == null)
                throw new Exception("voting info was null");

            var votingState = mapper.Map<VotingState>(votingInfo);

            if (votingInfo.IsLimited)
            {
                bool amongAllowed = votingInfo
                    .UserVotings
                    .First(i => i.User.Id == userId).UserStatus == UserStatus.Allowed;

                if (!amongAllowed)
                    return null;
            }

            if (votingInfo.IsClosed && DateTime.Now < votingInfo.DueDate)
                return votingState;

            if (votingInfo.IsAnonymous)
            {
                votingState.Choices = votingInfo.Options
                    .SelectMany(i => i.Choices)
                    .Select(i => new ChoiceInfo
                    {
                        OptionInfo = new OptionInfo
                        {
                            Description = i.Option.Description,
                        }
                    });
            }
            else
            {
                votingState.Choices = votingInfo.Options
                   .SelectMany(i => i.Choices)
                   .Select(i => new ChoiceInfo
                   {
                       OptionInfo = new OptionInfo
                       {
                           Description = i.Option.Description,
                       },
                       User = mapper.Map<UserLimited>(i.User)
                   });
            }

            var emptyOptionsChoices = votingInfo.Options
                .Where(i => i.Choices.Count == 0)
                .Select(j => new ChoiceInfo
                {
                    OptionInfo = new OptionInfo 
                    { 
                        Description = j.Description,
                        NeverChosen = true
                    } 
                });

            var allChoices = votingState.Choices.Concat(emptyOptionsChoices).ToArray();

            votingState.Choices = allChoices;

            return votingState;
        }
      
        public async Task<VotingEditModel> GetVotingEditModel(int votingId, string userId)
        {
            var voting = await ctx.Votings.Include(i => i.Options).FirstAsync(i => i.Id == votingId);

            if (voting.AuthorId != userId)
                return null;

            var editModel = mapper.Map<VotingEditModel>(voting);

            editModel.Options = voting.Options.Select(i => i.Description).ToArray();

            return editModel;
        }

        public Task<VotingRegisteringResult> Register(VotingInitialInfoModel model, string userId) 
            => Register(model, userId, null);

        public Task<VotingRegisteringResult> Edit(VotingEditModel model, string userId)
            => Register(model, userId, model.Id);
    }
}

