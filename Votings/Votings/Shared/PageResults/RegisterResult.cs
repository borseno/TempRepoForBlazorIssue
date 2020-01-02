using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Shared
{
    public class RegisterResult : ResultBase
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
