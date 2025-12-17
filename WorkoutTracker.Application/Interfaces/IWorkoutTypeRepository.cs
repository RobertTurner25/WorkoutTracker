using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IWorkoutTypeRepository
    {
        Task<WorkoutType?> GetByIdAsync(Guid id);

        Task<bool> ExistsAsync(Guid id);
    }
}
