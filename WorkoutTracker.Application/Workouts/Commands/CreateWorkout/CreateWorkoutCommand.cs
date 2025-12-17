using MediatR;

namespace WorkoutTracker.Application.Workouts.Commands.CreateWorkout
{
    public record CreateWorkoutCommand(DateTime Date, Guid? WorkoutTypeId) : IRequest<Guid>;
}
