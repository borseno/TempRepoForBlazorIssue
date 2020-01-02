using System.Net.Mail;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class FromMockeeMockersEmailSendingService : IEmailSendingService
    {
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            using var smtpClient = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("mockeemockers@gmail.com");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = message;

            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("mockeemockers@gmail.com", "mockomockomocko123#1");
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(mail);
        }
    }
}
