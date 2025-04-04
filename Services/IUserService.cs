using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Interface for user management operations
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>A collection of all users</returns>
        Task<IEnumerable<User>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by their ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<User?> GetUserByIdAsync(int id);

        /// <summary>
        /// Gets a user by their email address
        /// </summary>
        /// <param name="email">The email address</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<User?> GetUserByEmailAsync(string email);

        /// <summary>
        /// Creates a new user with the provided password
        /// </summary>
        /// <param name="user">The user to create</param>
        /// <param name="password">The plaintext password to hash and store</param>
        /// <returns>The created user</returns>
        Task<User> CreateUserAsync(User user, string password);

        /// <summary>
        /// Validates a user's credentials
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The plaintext password to check</param>
        /// <returns>True if the credentials are valid, otherwise false</returns>
        Task<bool> ValidateUserPasswordAsync(string email, string password);
    }
}