using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Api.Requests;
using WorkoutTracker.Application.Workouts.Commands.CreateWorkout;
using WorkoutTracker.Application.Workouts.Queries.GetWorkoutById;

namespace WorkoutTracker.Api.Controllers
{
    [ApiController]
    [Route("api/workouts")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WorkoutsController> _logger;

        public WorkoutsController(IMediator mediator, ILogger<WorkoutsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout(
            CreateWorkoutRequest request,
            CancellationToken ct
        )
        {
            var command = new CreateWorkoutCommand(request.Date, request.WorkoutTypeId);

            var workoutId = await _mediator.Send(command, ct);

            return CreatedAtAction(nameof(GetById), new { id = workoutId }, workoutId);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetWorkoutByIdQuery(id));

            return Ok(result);
        }
    }
}
