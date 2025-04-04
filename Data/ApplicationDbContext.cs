using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Models;

namespace WorkoutTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Workout> Workouts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                
                entity.HasMany(e => e.Workouts)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Workout entity
            modelBuilder.Entity<Workout>(entity =>
            {
                entity.Property(e => e.Duration).HasAnnotation("Range", new[] { 1, int.MaxValue });
                entity.Property(e => e.Calories).HasAnnotation("Range", new[] { 0, int.MaxValue });
            });
        }
    }
}