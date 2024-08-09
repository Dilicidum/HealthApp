using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class Sleep
    {
        public int Id { get; set; }

        public TimeSpan DurationOfSleep { get; set; }

        public List<SleepSample> SleepSamples { get; set; }
    }
}
