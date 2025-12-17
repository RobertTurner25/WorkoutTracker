using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Repositories
{
    public class WorkoutTypeRepository : IWorkoutTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutType?> GetByIdAsync(Guid id)
        {
            return await _context.WorkoutTypes.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.WorkoutTypes.AnyAsync(wt => wt.Id == id);
        }
    }
}
