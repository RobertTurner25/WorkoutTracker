namespace WorkoutTracker.Application.Sets.DTOs
{
    public sealed class SetDTO
    {
        public Guid Id { get; init; }
        public Guid WorkoutEntryId { get; init; }
        public int Reps { get; init; }
        public decimal Weight { get; init; }
    }
}
