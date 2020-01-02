using Microsoft.AspNetCore.Identity;
using Votings.Shared;
using System.Linq;

namespace Votings.Server.BusinessLayer.Extensions
{
    public static class IdentityResultExtensions
    {
        public static TResult ConvertIdentityResultToResult<TResult>(this IdentityResult userUpdateResult)
            where TResult : ResultBase, new()
                => new TResult
                {
                    Errors = userUpdateResult.Errors.Select(i => i.Description).ToArray(),
                    Successful = userUpdateResult.Succeeded
                };
    }
}
