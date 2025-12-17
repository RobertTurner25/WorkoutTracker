using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Workout> Workouts => Set<Workout>();
        public DbSet<WorkoutEntry> WorkoutEntries => Set<WorkoutEntry>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<Set> Sets => Set<Set>();
        public DbSet<WorkoutType> WorkoutTypes => Set<WorkoutType>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
