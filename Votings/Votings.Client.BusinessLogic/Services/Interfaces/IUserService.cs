using System.Threading.Tasks;
using Votings.Shared;

namespace Votings.Services
{
    public interface IUserService
    {
        Task<EditUserResult> ChangeData(ProfileModel model);
    }
}