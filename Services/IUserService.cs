using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// 
    /// Interface for user management operations
    /// 
    public interface IUserService
    {
        /// 
        /// Gets all users
        /// 
        /// <returns>A collection of all users</returns>
        Task<IEnumerable<User>> GetAllUsersAsync();

        /// 
        /// Gets a user by their ID
        /// 
        /// <param name="id">The user ID</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<User?> GetUserByIdAsync(int id);

        /// 
        /// Gets a user by their email address
        /// 
        /// <param name="email">The email address</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<User?> GetUserByEmailAsync(string email);

        /// 
        /// Creates a new user with the provided password
        /// 
        /// <param name="user">The user to create</param>
        /// <param name="password">The plaintext password to hash and store</param>
        /// <returns>The created user</returns>
        Task<User> CreateUserAsync(User user, string password);

        /// 
        /// Validates a user's credentials
        /// 
        /// <param name="email">The user's email</param>
        /// <param name="password">The plaintext password to check</param>
        /// <returns>True if the credentials are valid, otherwise false</returns>
        Task<bool> ValidateUserPasswordAsync(string email, string password);
    }
}