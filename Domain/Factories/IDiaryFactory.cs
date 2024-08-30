using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public interface IDiaryFactory
    {
        public Task<Diary> Create(string Description, string ShortDescription,int dayRating, DateTime? date =  null);
    }
}
