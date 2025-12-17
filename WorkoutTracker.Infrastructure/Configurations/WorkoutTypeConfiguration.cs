using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class WorkoutTypeConfiguration : IEntityTypeConfiguration<WorkoutType>
    {
        public void Configure(EntityTypeBuilder<WorkoutType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }
    }
}
