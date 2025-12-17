using FluentValidation;

namespace WorkoutTracker.Application.Workouts.Commands.CreateWorkout
{
    public sealed class CreateWorkoutValidator : AbstractValidator<CreateWorkoutCommand>
    {
        public CreateWorkoutValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Workout date is required.")
                .LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Workout date cannot be in the future.");

            RuleFor(x => x.WorkoutTypeId)
                .Must(id => id == null || id != Guid.Empty)
                .WithMessage("WorkoutTypeId cannot be an empty GUID.");
        }
    }
}
