using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Votings.Shared;

namespace Votings.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<EditUserResult> ChangeData(ProfileModel model)
            => _httpClient.PostJsonAsync<EditUserResult>("api/EditProfile/edit", model);
    }
}