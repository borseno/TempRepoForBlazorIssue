using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace Votings.Client
{
    public interface IApiAuthenticationStateProvider
    {
        Task<AuthenticationState> GetAuthenticationStateAsync();
        void MarkUserAsAuthenticated(string token);
        void MarkUserAsLoggedOut();
    }
}