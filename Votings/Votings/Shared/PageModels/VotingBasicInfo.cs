using System;
using System.ComponentModel.DataAnnotations;

namespace Votings.Shared.PageModels
{
    public class VotingEditModel : VotingInitialInfoModel
    {
        public int Id { get; set; }
    }

    public class VotingBasicInfo
    {        
        public string Name { get; set; }

        [Required(ErrorMessage = "Voting should have some description")]
        [MinLength(1, ErrorMessage = "Voting description should contain at least one character")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]        
        public DateTime DueDate { get; set; }
    }
}
