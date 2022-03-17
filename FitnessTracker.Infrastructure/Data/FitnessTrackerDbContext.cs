using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Data
{
    public class FitnessTrackerDbContext : IdentityDbContext
    {
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<FitnessProgram> FitnessPrograms { get; set; }
        public DbSet<FitnessTip> FitnessTips { get; set; }
        public DbSet<PersonalRecord> PersonalRecords { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SupplementationPlan> SupplementationPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFitnessProgram> UserFitnessPrograms { get; set; }
        public DbSet<UserPersonalRecord> UserPersonalRecords { get; set; }
        public DbSet<UserSupplementationPlan> UserSupplementationPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFitnessProgram>()
                .HasKey(x => new{ x.UserId, x.FitnessProgramId});

            builder.Entity<UserSupplementationPlan>()
                .HasKey(x => new { x.UserId, x.SupplementationPlanId });
        }
    }
}