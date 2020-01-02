using System.Threading.Tasks;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface IEmailSendingService
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}
