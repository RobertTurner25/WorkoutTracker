using WorkoutTracker.Application.WorkoutEntries;

namespace WorkoutTracker.Application.Workouts.DTOs
{
    public sealed class WorkoutDTO
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }
        public Guid? WorkoutTypeId { get; init; }
        public string? WorkoutTypeName { get; init; }

        public IReadOnlyList<WorkoutEntryDTO> Entries { get; init; } = [];
    }
}
