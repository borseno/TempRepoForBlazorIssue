using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Shared.PageModels
{
    public class VotingState : VotingBasicInfo
    {
        public IEnumerable<ChoiceInfo> Choices { get; set; }
    }

    public class ChoiceInfo
    {
        public UserLimited User { get; set; }
        public OptionInfo OptionInfo { get; set; }
    }

    public class OptionInfo
    {
        public string Description { get; set; }

        public bool NeverChosen { get; set; }
    }
}
