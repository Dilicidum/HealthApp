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
        public Diary Create(string Description, string ShortDescription, DateTime? date =  null);
    }
}
