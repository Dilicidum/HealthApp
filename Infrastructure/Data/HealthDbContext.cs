using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HealthDbContext: IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public DbSet<SleepSample> SleepSamples { get; set; }

        public DbSet<LearningItem> LearningItems { get; set; }

        public DbSet<Diary> Diaries { get; set; }

        public HealthDbContext(DbContextOptions<HealthDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SleepSample>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
