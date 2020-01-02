using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Votings.Client
{
    public class LogoutService : ILogoutService
    {
        private readonly HttpClient _httpClient;
        private readonly IApiAuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public LogoutService(HttpClient httpClient,
                   IApiAuthenticationStateProvider authenticationStateProvider,
                   ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _authenticationStateProvider.MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
