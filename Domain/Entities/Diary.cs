using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Diary
    {
        internal Diary() { }

        internal Diary(string description, string shortDescription, DateTime date) {
            Date = date;
            Description = description;
            ShortDescription = shortDescription;
        }

        public int Id { get; private set; }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }

        public string ShortDescription { get; private set; }
    }
}
