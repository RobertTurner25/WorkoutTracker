namespace WorkoutTracker.Api.Requests
{
    public class CreateWorkoutRequest
    {
        /// <summary>
        /// The date the workout was performed (client-provided).
        /// </summary>
        public DateTime Date { get; init; }

        /// <summary>
        /// Optional workout type. If provided, must be a valid, non-empty GUID.
        /// </summary>
        public Guid? WorkoutTypeId { get; init; }
    }
}
