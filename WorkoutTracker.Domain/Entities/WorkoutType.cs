using WorkoutTracker.Domain.Exceptions;

namespace WorkoutTracker.Domain.Entities
{
    public class WorkoutType
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        private WorkoutType() { }

        public WorkoutType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleViolationException("Workout type name cannot be empty.");

            Id = Guid.NewGuid();
            Name = name.Trim();
        }
    }
}
