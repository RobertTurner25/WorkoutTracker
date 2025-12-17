using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Workout workout, CancellationToken ct)
        {
            await _context.Workouts.AddAsync(workout, ct);
        }

        public async Task<Workout?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context
                .Workouts.Include(w => w.WorkoutEntries)
                    .ThenInclude(we => we.Sets)
                .Include(w => w.WorkoutEntries)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id, ct);
        }

        public Task RemoveAsync(Workout workout, CancellationToken ct)
        {
            _context.Workouts.Remove(workout);
            return Task.CompletedTask;
        }
    }
}
