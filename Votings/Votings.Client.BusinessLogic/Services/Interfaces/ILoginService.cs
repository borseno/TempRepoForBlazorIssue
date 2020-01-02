using Votings.Shared;
using System.Threading.Tasks;

namespace Votings.Client
{
    public interface ILoginService
    {
        Task<LoginResult> Login(LoginModel loginModel);
    }
}
