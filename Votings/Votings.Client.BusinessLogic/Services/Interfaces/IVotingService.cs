using System.Collections.Generic;
using System.Threading.Tasks;
using Votings.Shared.DTO;
using Votings.Shared.PageModels;
using Votings.Shared.PageResults;

namespace Votings.Client.BusinessLogic.Services.Interfaces
{
    public interface IVotingsService
    {
        Task<VotingRegisteringResult> RegisterVote(VotingInitialInfoModel model);
        Task<VotingState> GetVotingState(int id);
        Task<VotingEditModel> GetVotingEditModel(int id);
        Task<VotingRegisteringResult> EditVoting(VotingEditModel model);
        Task<IEnumerable<VotingReference>> GetVotingsReferences(bool currentUserOnly);
    }
}