using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Server.DAL.Models
{
    public class Choice
    {
        public User User { get; set; }
        public string UserId { get; set; }

        public Option Option { get; set; }
        public Guid OptionId { get; set; }
    }
}
