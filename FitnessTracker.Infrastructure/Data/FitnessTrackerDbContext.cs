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
        public DbSet<FitnessProgram> FitnessPrograms { get; set; }
        public DbSet<FitnessTip> FitnessTips { get; set; }
        public DbSet<PersonalRecord> PersonalRecords { get; set; }
        public DbSet<ProgramDay> ProgramDays { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SupplementationPlan> SupplementationPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.; Database = FitnessTrackerDB; Trusted_Connection = True; Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany<ProgramDay>(x => x.ProgramDays)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany<PersonalRecord>(x => x.PersonalRecords)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasOne<SupplementationPlan>()
                .WithOne()
                .HasForeignKey<SupplementationPlan>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}