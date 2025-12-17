using MediatR;
using WorkoutTracker.Application.Workouts.DTOs;

namespace WorkoutTracker.Application.Workouts.Queries.GetWorkoutById
{
    public sealed record GetWorkoutByIdQuery(Guid Id) : IRequest<WorkoutDTO>;
}
