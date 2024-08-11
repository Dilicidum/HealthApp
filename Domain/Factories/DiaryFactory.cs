using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
namespace Domain.Factories
{
    public class DiaryFactory : IDiaryFactory
    {
        public DiaryFactory() { }

        public Diary Create(string Description, string ShortDescription, DateTime? date = null)
        {
            if (string.IsNullOrEmpty(ShortDescription))
            {
                throw new InputValidationException("Short description cannot be empty");
            }

            var dateWritten = date == null ? DateTime.UtcNow : date.Value;

            var diaryItem = new Diary(Description, ShortDescription, dateWritten);

            return diaryItem;
        }
    }
}
