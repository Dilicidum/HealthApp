using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SleepSample
    {
        public int Id { get; set; }

        public string SourceName { get; set; }

        public double SourceVersion { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DateTime { get; set; }

        public SleepType SleepType { get; set; }
    }

    public enum SleepType
    {
        Core,
        REM,
        InBed,
        Awake,
        Unspecified
    }
}
