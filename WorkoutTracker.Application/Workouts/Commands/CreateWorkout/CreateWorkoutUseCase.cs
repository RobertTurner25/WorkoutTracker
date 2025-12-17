using System.ComponentModel.DataAnnotations;
using MediatR;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Workouts.Commands.CreateWorkout
{
    public sealed class CreateWorkoutUseCase : IRequestHandler<CreateWorkoutCommand, Guid>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IWorkoutTypeRepository _workoutTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkoutUseCase(
            IWorkoutRepository workoutRepository,
            IWorkoutTypeRepository workoutTypeRepository,
            IUnitOfWork unitOfWork
        )
        {
            _workoutRepository = workoutRepository;
            _workoutTypeRepository = workoutTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateWorkoutCommand command, CancellationToken ct)
        {
            Guid? workoutTypeId = null;

            if (command.WorkoutTypeId is not null)
            {
                var exists = await _workoutTypeRepository.ExistsAsync(command.WorkoutTypeId.Value);

                if (!exists)
                    throw new ValidationException("Specified workout type does not exist.");

                workoutTypeId = command.WorkoutTypeId.Value;
            }

            var workout = new Workout(command.Date, workoutTypeId);

            await _workoutRepository.AddAsync(workout, ct);

            await _unitOfWork.SaveChangesAsync(ct);
            return workout.Id;
        }
    }
}
