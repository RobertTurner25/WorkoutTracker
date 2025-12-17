using WorkoutTracker.Domain.Exceptions;

namespace WorkoutTracker.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public WorkoutType? Type { get; private set; }
        public Guid? TypeId { get; private set; }

        private readonly List<WorkoutEntry> _workoutEntries = new();
        public IReadOnlyCollection<WorkoutEntry> WorkoutEntries => _workoutEntries.AsReadOnly();

        public string DisplayName =>
            Type is not null ? $"{Date:yyyy-MM-dd} - {Type.Name}" : Date.ToString("yyyy-MM-dd");

        private Workout() { }

        public Workout(DateTime date, Guid? workoutTypeId)
        {
            if (date.Date > DateTime.Now.Date)
                throw new BusinessRuleViolationException("Workout date cannot be in the future.");

            Id = Guid.NewGuid();
            Date = date.Date;
            TypeId = workoutTypeId;
        }

        public WorkoutEntry AddWorkoutEntry(Guid exerciseId)
        {
            if (exerciseId == Guid.Empty)
                throw new BusinessRuleViolationException("Exercise ID cannot be empty.");

            var entry = new WorkoutEntry(this, exerciseId);
            _workoutEntries.Add(entry);
            return entry;
        }

        public void AddSetToEntry(Guid entryId, int reps, decimal weight)
        {
            var entry = _workoutEntries.FirstOrDefault(e => e.Id == entryId);

            if (entry is null)
                throw new BusinessRuleViolationException(
                    "The specified workout entry does not belong to this workout."
                );

            entry.AddSet(reps, weight);
        }
    }
}
