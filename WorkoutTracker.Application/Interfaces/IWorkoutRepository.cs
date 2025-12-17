using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IWorkoutRepository
    {
        Task AddAsync(Workout workout, CancellationToken ct);
        Task<Workout?> GetByIdAsync(Guid id, CancellationToken ct);

        Task RemoveAsync(Workout workout, CancellationToken ct);
    }
}
