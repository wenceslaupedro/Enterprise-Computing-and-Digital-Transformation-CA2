using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WorkoutTracker.Data;
using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// 
    /// Implementation of the IUserService interface
    /// 
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        /// 
        /// Initializes a new instance of the UserService class
        /// 
        /// <param name="context">The application database context</param>
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        /// <inheritdoc/>
        public async Task<User> CreateUserAsync(User user, string password)
        {
            // Check if user with the same email already exists
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == user.Email.ToLower()))
            {
                throw new InvalidOperationException("A user with this email already exists");
            }

            // Hash the password
            user.PasswordHash = HashPassword(password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        /// <inheritdoc/>
        public async Task<bool> ValidateUserPasswordAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            return VerifyPassword(password, user.PasswordHash);
        }

        /// 
        /// Hashes a password using SHA256
        /// 
        /// <param name="password">The plaintext password</param>
        /// <returns>The hashed password</returns>
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        /// 
        /// Verifies a password against a hash
        /// 
        /// <param name="password">The plaintext password</param>
        /// <param name="hash">The hashed password</param>
        /// <returns>True if the password is correct, otherwise false</returns>
        private bool VerifyPassword(string password, string hash)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hash;
        }
    }
}