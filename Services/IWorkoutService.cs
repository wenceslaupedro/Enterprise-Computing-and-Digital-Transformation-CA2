using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Interface for workout management operations
    /// </summary>
    public interface IWorkoutService
    {
        /// <summary>
        /// Gets all workouts
        /// </summary>
        /// <returns>A collection of all workouts</returns>
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();

        /// <summary>
        /// Gets all workouts for a specific user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>A collection of workouts for the user</returns>
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(int userId);

        /// <summary>
        /// Gets all workouts for a specific user in a specific month
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month (1-12)</param>
        /// <returns>A collection of workouts for the user in the specified month</returns>
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAndMonthAsync(int userId, int year, int month);

        /// <summary>
        /// Gets a workout by its ID
        /// </summary>
        /// <param name="id">The workout ID</param>
        /// <returns>The workout if found, otherwise null</returns>
        Task<Workout?> GetWorkoutByIdAsync(int id);

        /// <summary>
        /// Creates a new workout
        /// </summary>
        /// <param name="workout">The workout to create</param>
        /// <returns>The created workout</returns>
        Task<Workout> CreateWorkoutAsync(Workout workout);

        /// <summary>
        /// Updates an existing workout
        /// </summary>
        /// <param name="workout">The workout with updated information</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateWorkoutAsync(Workout workout);

        /// <summary>
        /// Deletes a workout
        /// </summary>
        /// <param name="id">The ID of the workout to delete</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteWorkoutAsync(int id);

        /// <summary>
        /// Gets analysis of a user's workout history
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>Analysis of the user's workouts</returns>
        Task<WorkoutAnalysis> GetUserWorkoutAnalysisAsync(int userId);
    }
}