using System.Threading.Tasks;
using Votings.Shared;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResult> Login(LoginModel login);
    }
}