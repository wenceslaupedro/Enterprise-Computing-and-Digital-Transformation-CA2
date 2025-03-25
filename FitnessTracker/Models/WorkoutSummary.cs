namespace FitnessTracker.Models
{
    public class WorkoutSummary
    {
        public int WorkoutID {get; set;}
        public int UserID {get; set;} 
        public DateTime WorkoutDate {get; set;}
        public string? Type {get; set;}
        public int DurationMinutes {get; set;}
        public int? CaloriesBurned {get; set;} 
        public required User User {get; set;} 
    }
}