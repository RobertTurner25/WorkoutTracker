using MediatR;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Sets.DTOs;
using WorkoutTracker.Application.WorkoutEntries;
using WorkoutTracker.Application.Workouts.DTOs;

namespace WorkoutTracker.Application.Workouts.Queries.GetWorkoutById
{
    public sealed class GetWorkoutByIdQueryHandler
        : IRequestHandler<GetWorkoutByIdQuery, WorkoutDTO>
    {
        private readonly IWorkoutRepository _repository;

        public GetWorkoutByIdQueryHandler(IWorkoutRepository repository)
        {
            _repository = repository;
        }

        public async Task<WorkoutDTO> Handle(GetWorkoutByIdQuery request, CancellationToken ct)
        {
            var workout = await _repository.GetByIdAsync(request.Id, ct);
            if (workout is null)
            {
                throw new KeyNotFoundException($"Workout with ID {request.Id} was not found.");
            }
            return new WorkoutDTO
            {
                Id = workout.Id,
                Date = workout.Date,
                WorkoutTypeId = workout.TypeId,
                WorkoutTypeName = workout.DisplayName,
                Entries = workout
                    .WorkoutEntries.Select(we => new WorkoutEntryDTO
                    {
                        Id = we.Id,
                        ExerciseId = we.ExerciseId,
                        ExerciseName = we.Exercise.Name,
                        Sets = we
                            .Sets.Select(s => new SetDTO
                            {
                                Id = s.Id,
                                Reps = s.Reps,
                                Weight = s.Weight,
                            })
                            .ToList(),
                    })
                    .ToList(),
            };
        }
    }
}
