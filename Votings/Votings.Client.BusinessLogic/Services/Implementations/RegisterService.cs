using Microsoft.AspNetCore.Components;
using Votings.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Votings.Client
{

    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<RegisterResult> Register(RegisterModel registerModel) 
            => _httpClient.PostJsonAsync<RegisterResult>("api/register", registerModel);
    }
}
