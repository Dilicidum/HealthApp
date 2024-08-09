using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public class LearningItemFactory : ILearningItemFactory
    {
        public LearningItem Create(LearningType learningType, bool isCompleted, string details, DateTime? date = null)
        {
            var dateCompleted = date.HasValue ? date.Value : DateTime.Now;

            return new LearningItem(learningType, isCompleted, details, dateCompleted);
        }
    }
}
