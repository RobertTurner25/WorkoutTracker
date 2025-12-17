using WorkoutTracker.Domain.Exceptions;

namespace WorkoutTracker.Domain.Entities
{
    public class Set
    {
        public Guid Id { get; private set; }
        public Guid WorkoutEntryId { get; private set; }
        public WorkoutEntry WorkoutEntry { get; private set; } = null!;
        public int Reps { get; private set; }
        public decimal Weight { get; private set; }

        private Set() { }

        internal Set(WorkoutEntry entry, int reps, decimal weight)
        {
            if (entry is null)
                throw new InvariantViolationException("Workout entry is required.");

            if (reps <= 0)
                throw new BusinessRuleViolationException("Repetitions must be greater than zero.");

            Id = Guid.NewGuid();
            WorkoutEntry = entry;
            WorkoutEntryId = entry.Id;
            Reps = reps;
            Weight = weight;
        }
    }
}
