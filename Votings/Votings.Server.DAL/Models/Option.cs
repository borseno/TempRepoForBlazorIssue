using System;
using System.Collections.Generic;

namespace Votings.Server.DAL.Models
{
    public class Option : EntityBase<Guid>
    {
        public Voting Voting { get; set; }
        public int VotingId { get; set; }
        
        public string Description { get; set; }

        public ICollection<Choice> Choices { get; set; }
    }
}
