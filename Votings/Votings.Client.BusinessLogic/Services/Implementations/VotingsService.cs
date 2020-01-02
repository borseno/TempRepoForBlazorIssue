using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Votings.Client.BusinessLogic.Services.Interfaces;
using Votings.Shared.DTO;
using Votings.Shared.PageModels;
using Votings.Shared.PageResults;

namespace Votings.Client.BusinessLogic.Services.Implementations
{
    public class VotingsService : IVotingsService
    {
        private readonly HttpClient client;

        public VotingsService(HttpClient client)
        {
            this.client = client;
        }

        public Task<VotingState> GetVotingState(int id)
        {

            return client.GetJsonAsync<VotingState>($"api/votings/state/{id}");
        }

        public Task<VotingEditModel> GetVotingEditModel(int id)
            => client.GetJsonAsync<VotingEditModel>($"api/votings/editmodel/{id}");

        public Task<VotingRegisteringResult> EditVoting(VotingEditModel model)
            => client.PostJsonAsync<VotingRegisteringResult>($"api/votings/edit", model);

        public Task<IEnumerable<VotingReference>> GetVotingsReferences(bool currentUserOnly)
            => client.GetJsonAsync<IEnumerable<VotingReference>>($"api/votings/references/{currentUserOnly}");

        public Task<VotingRegisteringResult> RegisterVote(VotingInitialInfoModel model)
        {
            var errors = model.GetValidationErrors();

            if (errors?.Count == 0)
            {
                return client.PostJsonAsync<VotingRegisteringResult>("api/votings/register", model);
            }
            else
            {
                var badResult = new VotingRegisteringResult
                {
                    Errors = errors
                };

                return Task.FromResult(badResult);
            }
        }
    }
}
