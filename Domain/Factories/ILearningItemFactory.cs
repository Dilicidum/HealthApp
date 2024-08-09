using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public interface ILearningItemFactory
    {
        public LearningItem Create(LearningType learningType, bool isCompleted, string description, DateTime? date = null);
    }
}
