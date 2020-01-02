using System.Collections.Generic;
using System.Threading.Tasks;
using Votings.Shared.DTO;
using Votings.Shared.PageModels;
using Votings.Shared.PageResults;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface IVotingsService
    {
        Task<VotingState> GetVotingStateAsync(int votingId, string userId);
        Task<VotingRegisteringResult> Register(VotingInitialInfoModel model, string userId);

        Task<VotingRegisteringResult> Edit(VotingEditModel model, string userId);
        Task<VotingEditModel> GetVotingEditModel(int votingId, string userId);
        Task<IEnumerable<VotingReference>> GetVotingsReferencesAsync(bool currentUserOnly, string userId);
    }
}