using WorkoutTracker.Application.Sets.DTOs;

namespace WorkoutTracker.Application.WorkoutEntries
{
    public sealed class WorkoutEntryDTO
    {
        public Guid Id { get; init; }
        public Guid ExerciseId { get; init; }
        public string ExerciseName { get; init; } = string.Empty;
        public Guid WorkoutId { get; init; }
        public IReadOnlyList<SetDTO> Sets { get; init; } = [];
    }
}
