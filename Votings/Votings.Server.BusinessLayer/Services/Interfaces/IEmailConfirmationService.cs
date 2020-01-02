using System.Threading.Tasks;
using Votings.Shared.PageResults;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface IEmailConfirmationService
    {
        Task<EmailConfirmationResult> Confirm(string userId, string token);
    }
}