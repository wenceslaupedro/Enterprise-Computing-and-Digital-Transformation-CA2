using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ExerciseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        public int Duration { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }

        [Column(TypeName = "decimal(12,3)")]
        public decimal Weight { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; } = null!;
        public virtual Exercise Exercise { get; set; } = null!;
    }
}