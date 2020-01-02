using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Votings.Shared;
using System.Threading.Tasks;
using Votings.Shared.Extensions;
using Votings.Server.DAL.Models;
using Votings.Server.BusinessLayer.Extensions;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResult> RegisterUser(RegisterModel model)
        {
            var newUser = new User
            {
                UserName = model.Username,
                Email = model.Email
            };

            if (await EmailAlreadyInUse(model.Email))
            {
                return AlreadyInUseResult(model);
            }

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return result.ConvertIdentityResultToResult<RegisterResult>();
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            var registerResult = ResultBase.SuccessfulResult<RegisterResult>();

            registerResult.Token = token;
            registerResult.UserEmail = newUser.Email;
            registerResult.UserId = newUser.Id;

            return registerResult;
        }

        private Task<bool> EmailAlreadyInUse(string email)
            => _userManager.Users.AnyAsync(i => i.Email == email);

        private static RegisterResult AlreadyInUseResult(RegisterModel model)
        => new RegisterResult
        {
            Successful = false,
            Errors = $"{model.Email} address is already in use".ObjectToArray()
        };
    }
}
