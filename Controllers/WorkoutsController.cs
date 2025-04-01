using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // GET: api/Workouts/Analysis/User/5
        [HttpGet("Analysis/User/{userId}")]
        public async Task<ActionResult<object>> GetUserWorkoutAnalysis(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId)
                .ToListAsync();

            if (!workouts.Any())
            {
                return Ok(new
                {
                    UserId = userId,
                    UserName = user.Name,
                    TotalWorkouts = 0,
                    Message = "No workouts found for this user"
                });
            }

            // Perform analysis
            var analysis = new
            {
                UserId = userId,
                UserName = user.Name,
                TotalWorkouts = workouts.Count,
                TotalCaloriesBurned = workouts.Sum(w => w.Calories),
                TotalMinutesExercised = workouts.Sum(w => w.Duration),
                AverageCaloriesPerWorkout = workouts.Average(w => w.Calories),
                AverageDurationPerWorkout = workouts.Average(w => w.Duration),
                MostCommonWorkoutType = workouts.GroupBy(w => w.Type)
                    .OrderByDescending(g => g.Count())
                    .First().Key,
                FirstWorkoutDate = workouts.Min(w => w.Date),
                LastWorkoutDate = workouts.Max(w => w.Date)
            };

            return Ok(analysis);
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkout), new { id = workout.Id }, workout);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.Id == id);
        }
    }
}