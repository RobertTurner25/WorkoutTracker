using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkoutTracker.Infrastructure;

var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=WorkoutTracker;Username=postgres;Password=postgres")
);

using var provider = services.BuildServiceProvider();
