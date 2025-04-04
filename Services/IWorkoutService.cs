using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// 
    /// Interface for workout management operations
    /// 
    public interface IWorkoutService
    {
        /// 
        /// Gets all workouts
        /// 
        /// <returns>A collection of all workouts</returns>
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();

        /// 
        /// Gets all workouts for a specific user
        /// 
        /// <param name="userId">The user ID</param>
        /// <returns>A collection of workouts for the user</returns>
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(int userId);

        /// 
        /// Gets all workouts for a specific user in a specific month
        /// 
        /// <param name="userId">The user ID</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month (1-12)</param>
        /// <returns>A collection of workouts for the user in the specified month</returns>
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAndMonthAsync(int userId, int year, int month);

        /// 
        /// Gets a workout by its ID
        /// 
        /// <param name="id">The workout ID</param>
        /// <returns>The workout if found, otherwise null</returns>
        Task<Workout?> GetWorkoutByIdAsync(int id);

        /// 
        /// Creates a new workout
        /// 
        /// <param name="workout">The workout to create</param>
        /// <returns>The created workout</returns>
        Task<Workout> CreateWorkoutAsync(Workout workout);

        /// 
        /// Updates an existing workout
        /// 
        /// <param name="workout">The workout with updated information</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateWorkoutAsync(Workout workout);

        /// 
        /// Deletes a workout
        /// 
        /// <param name="id">The ID of the workout to delete</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteWorkoutAsync(int id);

        /// 
        /// Gets analysis of a user's workout history
        /// 
        /// <param name="userId">The user ID</param>
        /// <returns>Analysis of the user's workouts</returns>
        Task<WorkoutAnalysis> GetUserWorkoutAnalysisAsync(int userId);
    }
}