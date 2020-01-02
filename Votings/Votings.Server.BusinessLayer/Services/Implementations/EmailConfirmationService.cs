using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Votings.Shared.PageResults;
using Votings.Shared.Extensions;
using Votings.Server.DAL.Models;
using Votings.Server.BusinessLayer.Extensions;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly UserManager<User> userManager;

        public EmailConfirmationService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<EmailConfirmationResult> Confirm(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return new EmailConfirmationResult
                {
                    Successful = false,
                    Errors = "userId or token is empty".ObjectToArray()
                };
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new EmailConfirmationResult
                {
                    Successful = false,
                    Errors = "no such user found in the queue for email confirmation".ObjectToArray()
                };
            }

            var identityResult = await userManager.ConfirmEmailAsync(user, token);

            return identityResult.ConvertIdentityResultToResult<EmailConfirmationResult>();
        }
    }
}
