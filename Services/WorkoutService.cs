using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Implementation of the IWorkoutService interface
    /// </summary>
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the WorkoutService class
        /// </summary>
        /// <param name="context">The application database context</param>
        public WorkoutService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(int userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.Date)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAndMonthAsync(int userId, int year, int month)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId && 
                            w.Date.Year == year && 
                            w.Date.Month == month)
                .OrderBy(w => w.Date)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Workout?> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workouts.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<Workout> CreateWorkoutAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateWorkoutAsync(Workout workout)
        {
            var existingWorkout = await _context.Workouts.FindAsync(workout.Id);
            if (existingWorkout == null)
            {
                return false;
            }

            // Update properties
            existingWorkout.Type = workout.Type;
            existingWorkout.Duration = workout.Duration;
            existingWorkout.Calories = workout.Calories;
            existingWorkout.Date = workout.Date;

            await _context.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return false;
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<WorkoutAnalysis> GetUserWorkoutAnalysisAsync(int userId)
        {
            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId)
                .ToListAsync();
                
            if (!workouts.Any())
            {
                return new WorkoutAnalysis
                {
                    TotalWorkouts = 0,
                    TotalDurationMinutes = 0,
                    TotalCaloriesBurned = 0,
                    AverageDurationMinutes = 0,
                    AverageCaloriesBurned = 0
                };
            }

            // Calculate basic stats
            var totalWorkouts = workouts.Count;
            var totalDuration = workouts.Sum(w => w.Duration);
            var totalCalories = workouts.Sum(w => w.Calories);
            
            // Calculate distribution by workout type
            var typeDistribution = workouts
                .GroupBy(w => w.Type)
                .ToDictionary(g => g.Key, g => g.Count());
                
            // Calculate monthly statistics
            var monthlyStats = workouts
                .GroupBy(w => new { w.Date.Year, w.Date.Month })
                .Select(g => new MonthlyStats
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    WorkoutCount = g.Count(),
                    TotalDuration = g.Sum(w => w.Duration),
                    TotalCalories = g.Sum(w => w.Calories)
                })
                .OrderBy(s => s.Year)
                .ThenBy(s => s.Month)
                .ToList();

            return new WorkoutAnalysis
            {
                TotalWorkouts = totalWorkouts,
                TotalDurationMinutes = totalDuration,
                TotalCaloriesBurned = totalCalories,
                AverageDurationMinutes = (double)totalDuration / totalWorkouts,
                AverageCaloriesBurned = (double)totalCalories / totalWorkouts,
                WorkoutTypeDistribution = typeDistribution,
                MonthlyStatistics = monthlyStats
            };
        }
    }
}