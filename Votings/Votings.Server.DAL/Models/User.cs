using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Votings.Server.DAL.Models
{

    public class User : IdentityUser
    {
        // add other custom properties for the user model here...
        public ICollection<Voting> CreatedVotings { get; set; }

        public ICollection<UserVotingStatus> UserVotings { get; set; }

        public ICollection<Choice> Choices { get; set; }
    }
}
