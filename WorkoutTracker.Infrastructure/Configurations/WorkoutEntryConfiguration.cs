using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class WorkoutEntryConfiguration : IEntityTypeConfiguration<WorkoutEntry>
    {
        public void Configure(EntityTypeBuilder<WorkoutEntry> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.Workout)
                .WithMany(w => w.WorkoutEntries)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(builder => builder.Exercise)
                .WithMany()
                .HasForeignKey(builder => builder.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(we => we.Sets)
                .WithOne(s => s.WorkoutEntry)
                .HasForeignKey(s => s.WorkoutEntryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
