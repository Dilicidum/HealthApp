using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistance
{
    public interface IApplicationContext
    {
        DbSet<SleepSample> SleepSamples { get; set; }

        DbSet<LearningItem> LearningItems { get; set; }

        DbSet<Diary> Diaries { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
