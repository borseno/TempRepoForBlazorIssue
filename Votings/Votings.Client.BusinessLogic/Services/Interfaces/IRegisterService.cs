using Votings.Shared;
using System.Threading.Tasks;

namespace Votings.Client
{
    public interface IRegisterService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
