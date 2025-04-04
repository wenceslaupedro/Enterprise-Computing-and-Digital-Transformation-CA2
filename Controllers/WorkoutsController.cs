using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Models;
using WorkoutTracker.Services;

namespace WorkoutTracker.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            var workouts = await _workoutService.GetAllWorkoutsAsync();
            return Ok(workouts);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // GET: api/Workouts/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkoutsByUser(int userId)
        {
            var workouts = await _workoutService.GetWorkoutsByUserIdAsync(userId);
            return Ok(workouts);
        }
        
        // GET: api/Workouts/User/5/2023/10
        [HttpGet("User/{userId}/{year}/{month}")]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkoutsByUserAndMonth(int userId, int year, int month)
        {
            var workouts = await _workoutService.GetWorkoutsByUserIdAndMonthAsync(userId, year, month);
            return Ok(workouts);
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<ActionResult<Workout>> CreateWorkout(Workout workout)
        {
            var createdWorkout = await _workoutService.CreateWorkoutAsync(workout);
            return CreatedAtAction(nameof(GetWorkout), new { id = createdWorkout.Id }, createdWorkout);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            var success = await _workoutService.UpdateWorkoutAsync(workout);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var success = await _workoutService.DeleteWorkoutAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        // GET: api/Workouts/Analysis/5
        [HttpGet("Analysis/{userId}")]
        public async Task<ActionResult<WorkoutAnalysis>> GetWorkoutAnalysis(int userId)
        {
            var analysis = await _workoutService.GetUserWorkoutAnalysisAsync(userId);
            return Ok(analysis);
        }
    }
}