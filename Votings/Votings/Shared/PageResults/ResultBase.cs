using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Shared
{
    public abstract class ResultBase
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static TResult SuccessfulResult<TResult>() where TResult : ResultBase, new()
            => new TResult
            {
                Successful = true
            };
    }
}
