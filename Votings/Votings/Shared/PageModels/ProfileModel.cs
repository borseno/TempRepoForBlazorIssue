using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Votings.Shared
{
    public class ProfileModel
    {
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
