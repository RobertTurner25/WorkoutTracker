using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(
            Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Workout> builder
        )
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Date).IsRequired();

            builder
                .HasMany(w => w.WorkoutEntries)
                .WithOne(e => e.Workout)
                .HasForeignKey(we => we.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(w => w.Type)
                .WithMany()
                .HasForeignKey(w => w.TypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
