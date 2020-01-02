using Microsoft.AspNetCore.Identity;
using Votings.Shared;
using System.Threading.Tasks;
using Votings.Server.DAL.Models;
using Votings.Server.BusinessLayer.Extensions;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class EditProfileService : IEditProfileService
    {
        private readonly UserManager<User> _userManager;

        public EditProfileService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<EditUserResult> EditUser(ProfileModel model)
        {
            User user = await ProfileModelToUser(model);

            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

            if (!passwordChangeResult.Succeeded)
            {
                return passwordChangeResult.ConvertIdentityResultToResult<EditUserResult>();
            }

            var userUpdateResult = await _userManager.UpdateAsync(user);

            if (!userUpdateResult.Succeeded)
            {
                return userUpdateResult.ConvertIdentityResultToResult<EditUserResult>();
            }

            return ResultBase.SuccessfulResult<EditUserResult>();
        }

        private async Task<User> ProfileModelToUser(ProfileModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            user.UserName = model.Login;
            return user;
        }
    }
}
