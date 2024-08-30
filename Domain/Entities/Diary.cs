using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.Entities
{
   public class Diary
    {
        internal Diary() { }

        internal Diary(string description, string shortDescription, int dayRating, DateTime date) {
            Date = date;
            Description = description;
            ShortDescription = shortDescription;
            DayRating = dayRating;
        }

        public int Id { get; private set; }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }

        public int DayRating { get; private set; }

        public string ShortDescription { get; private set; }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new InputValidationException("You can`t update description with empty string");
            }

            Description = description;
        }

        public void ChangeShortDescription(string shortDescription)
        {
            if (string.IsNullOrEmpty(shortDescription))
            {
                throw new InputValidationException("You can`t update description with empty string");
            }

            ShortDescription = shortDescription;
        }

        public void ChangeDayRating(int dayRating)
        {
            if (dayRating <= 0 || dayRating > 10)
            {
                throw new InputValidationException("Rating of the day should be within 1 to 10 range");
            }

            DayRating = dayRating;
        }
    }
}
