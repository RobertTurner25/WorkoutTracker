namespace WorkoutTracker.Domain.Exceptions
{
    public sealed class InvariantViolationException : DomainException
    {
        public InvariantViolationException(string message)
            : base(message) { }
    }
}
