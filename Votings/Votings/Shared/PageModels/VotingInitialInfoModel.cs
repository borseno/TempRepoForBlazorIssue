using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Votings.Shared.PageModels
{

    public class VotingInitialInfoModel : VotingBasicInfo
    {

        [Range(0, int.MaxValue)]
        public int MinChoicesAmount { get; set; }

        [Range(0, int.MaxValue)]
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


        [Required(ErrorMessage = "Please add at least one option")]
        public IEnumerable<string> Options { get; set; }

        public IEnumerable<string> Usernames { get; set; }
    }

    public static class VotingInitialInfoModelValidator
    {   
        public static List<string> GetValidationErrors(this VotingInitialInfoModel model)
        {
            bool endGreaterThanOrEqualToStart = model.DueDate >= model.StartDate;
            bool maxGreaterThanOrEqualToMin = model.MaxChoicesAmount >= model.MinChoicesAmount;
            bool maxLessThanOrEqualToCount = model.MaxChoicesAmount <= (model.Options?.Count() ?? 0);
            bool isDateTimeTodayOrLater = model.StartDate >= DateTime.Now;

            var result = new List<string>(3);

            if (!endGreaterThanOrEqualToStart)
                result.Add("End date is less than start date");

            if (!maxGreaterThanOrEqualToMin)
                result.Add("Max choices is less than min choices amount");

            if (!maxLessThanOrEqualToCount)
                result.Add("Max is greater than amount of choices");

            if (!isDateTimeTodayOrLater)
                result.Add("Datetime should be not earlier than current datetime");

            return result;
        }
    }
}
