using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Server.DAL.Models
{
    public class UserVotingStatus
    {
        public User User { get; set; }
        public string UserId { get; set; }

        public Voting Voting { get; set; }
        public int VotingId { get; set; }

        public UserStatus UserStatus { get; set; }
    }
}
