using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Votings.Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Votings.Client
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly IApiAuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public LoginService(HttpClient httpClient,
                           IApiAuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var result = await _httpClient.PostJsonAsync<LoginResult>("api/Login", loginModel);

            if (result.Successful)
            {
                await _localStorage.SetItemAsync("authToken", result.Token);
                _authenticationStateProvider.MarkUserAsAuthenticated(result.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);               
            }

            return result;
        }
    }
}
