using WorkoutTracker.Domain.Exceptions;

namespace WorkoutTracker.Domain.Entities
{
    public class WorkoutEntry
    {
        public Guid Id { get; private set; }
        public Guid WorkoutId { get; private set; }
        public Workout Workout { get; private set; } = null!;
        public Guid ExerciseId { get; private set; }
        public Exercise Exercise { get; private set; } = null!;
        public List<Set> Sets { get; private set; } = new List<Set>();

        private WorkoutEntry() { }

        internal WorkoutEntry(Workout workout, Guid exerciseId)
        {
            if (workout is null)
                throw new InvariantViolationException("Workout is required.");

            if (exerciseId == Guid.Empty)
                throw new BusinessRuleViolationException("Exercise ID cannot be empty.");

            Id = Guid.NewGuid();
            Workout = workout;
            WorkoutId = workout.Id;
            ExerciseId = exerciseId;
        }

        public Set AddSet(int reps, decimal weight)
        {
            if (reps <= 0)
                throw new BusinessRuleViolationException("Repetitions must be greater than zero.");

            var set = new Set(this, reps, weight);
            Sets.Add(set);

            return set;
        }
    }
}
