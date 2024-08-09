using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LearningItem
    {
        internal LearningItem() { }

        internal LearningItem(LearningType type, bool isCompleted, string details,DateTime date) {
            LearningType = type;
            IsCompleted = isCompleted;
            Details = details;
            Date = date;
        }

        public int Id { get; private set; }

        public LearningType LearningType { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime Date { get; private set; }

        public string Details { get; private set; }
    }

    public enum LearningType
    {
        English, 
        ClearArchitecture,
        LeetCode,
        PetProject
    }
}
