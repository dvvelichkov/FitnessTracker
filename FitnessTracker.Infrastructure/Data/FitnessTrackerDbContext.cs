using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Data
{
    public class FitnessTrackerDbContext : IdentityDbContext<User>
    {
        public FitnessTrackerDbContext()
        {

        }
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInFitnessProgram> ExercisesInFitnessPrograms { get; set; }
        public DbSet<FitnessProgram> FitnessPrograms { get; set; }
        public DbSet<FitnessTip> FitnessTips { get; set; }
        public DbSet<PersonalRecord> PersonalRecords { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SupplementationPlan> SupplementationPlans { get; set; }
        public DbSet<SupplementInSupplementationPlan> SupplementsInSupplementationPlans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.; Database = FitnessTrackerDB; Trusted_Connection = True; Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ExerciseInFitnessProgram>()
                .HasKey(x => new { x.ExerciseId, x.FitnessProgramId });

            builder.Entity<SupplementInSupplementationPlan>()
                .HasKey(x => new { x.SupplementId, x.SupplementationPlanId });

            //builder.Entity<User>()
            //    .HasMany(x => x.FitnessPrograms)
            //    .WithOne()
            //    .HasForeignKey(x => x.UserId)
            //    .HasPrincipalKey(x => x.Id);

            //builder.Entity<User>()
            //    .HasMany(x => x.PersonalRecords)
            //    .WithOne()
            //    .HasForeignKey(x => x.UserId)
            //    .HasPrincipalKey(x => x.Id);

            //builder.Entity<User>()
            //    .HasMany(x => x.SupplementationPlans)
            //    .WithOne()
            //    .HasForeignKey(x => x.UserId)
            //    .HasPrincipalKey(x => x.Id);
        }
    }
}