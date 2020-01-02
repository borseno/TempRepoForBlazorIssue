using System.Threading.Tasks;
using Votings.Shared;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface IEditProfileService
    {
        Task<EditUserResult> EditUser(ProfileModel model);
    }
}