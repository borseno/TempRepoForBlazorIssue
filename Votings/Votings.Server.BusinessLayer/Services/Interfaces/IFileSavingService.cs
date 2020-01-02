using System.Threading.Tasks;

namespace Votings.Server.BusinessLayer.Services.Interfaces
{
    public interface IFileSavingService
    {
        Task<string> SaveFileAsync(byte[] bytes, string fileType, string subpath);
        Task<string> SaveFileAsync(string bytesEncoded, string fileType, string subpath);
    }
}