﻿using System.Threading.Tasks;
using Votings.Shared;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface IRegisterUserService
    {
        Task<RegisterResult> RegisterUser(RegisterModel model);
    }
}