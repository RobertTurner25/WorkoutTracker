using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class SetConfiguration : IEntityTypeConfiguration<Set>
    {
        public void Configure(EntityTypeBuilder<Set> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Reps).IsRequired();

            builder
                .HasOne(e => e.WorkoutEntry)
                .WithMany(we => we.Sets)
                .HasForeignKey(e => e.WorkoutEntryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
