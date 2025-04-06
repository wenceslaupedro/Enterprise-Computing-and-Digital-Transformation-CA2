// Models/Exercise.cs
using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string MuscleGroup { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string DifficultyLevel { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}