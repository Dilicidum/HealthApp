using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Persistance;
using Microsoft.EntityFrameworkCore;
namespace Domain.Factories
{
    public class DiaryFactory(IApplicationContext context) : IDiaryFactory
    {

        public async Task<Diary> Create(string Description, string ShortDescription, DateTime? date = null)
        {
            if (string.IsNullOrEmpty(ShortDescription))
            {
                throw new InputValidationException("Short description cannot be empty");
            }

            var dateWritten = date == null ? DateTime.UtcNow.Date : date.Value.Date;

            var diary = await context.Diaries.Where(d => d.Date.Date == dateWritten).FirstOrDefaultAsync();

            if (diary is not null)
            {
                throw new InputValidationException("You can only have one record per day, update diary record instead");
            }

            var diaryItem = new Diary(Description, ShortDescription, dateWritten);

            return diaryItem;
        }
    }
}
