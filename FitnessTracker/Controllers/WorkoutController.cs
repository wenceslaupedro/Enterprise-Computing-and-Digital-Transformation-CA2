using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        [HttpGet("summary")]
        public IActionResult GetWorkoutSummary()
        {
            // Simulated workout stats
            var summary = new
            {
                TotalWorkouts = 18,
                ActiveDays = 12,
                SkippedDays = 6
            };

            return Ok(summary);
        }
    }
}