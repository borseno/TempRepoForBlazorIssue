using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Shared.DTO
{
    public class VotingReference
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
    }
}
