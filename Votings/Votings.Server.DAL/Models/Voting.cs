using System;
using System.Collections.Generic;

namespace Votings.Server.DAL.Models
{
    public class Voting : EntityBase
    {        
        public User Author { get; set; }
        public string AuthorId { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }


        public int MinChoicesAmount { get; set; }

        public int MaxChoicesAmount { get; set; }

        /// <summary>
        /// Closed voting is voting its results are not exposed to its participants until the end of the voting
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Limited voting is voting in which only particular users can participate
        /// </summary>
        public bool IsLimited { get; set; }
        
        /// <summary>
        /// Anonymous voting is voting authors of options are never exposed to public
        /// </summary>
        public bool IsAnonymous { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public ICollection<Option> Options { get; set; }
        
        public ICollection<UserVotingStatus> UserVotings { get; set; } // m-m voting-user
    }
}
