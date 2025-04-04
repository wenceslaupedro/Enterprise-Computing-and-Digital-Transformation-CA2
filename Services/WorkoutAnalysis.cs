namespace WorkoutTracker.Services
{
    /// <summary>
    /// Class representing analysis of a user's workout history
    /// </summary>
    public class WorkoutAnalysis
    {
        /// <summary>
        /// Total number of workouts completed
        /// </summary>
        public int TotalWorkouts { get; set; }
        
        /// <summary>
        /// Total duration of all workouts in minutes
        /// </summary>
        public int TotalDurationMinutes { get; set; }
        
        /// <summary>
        /// Total calories burned across all workouts
        /// </summary>
        public int TotalCaloriesBurned { get; set; }
        
        /// <summary>
        /// Average duration of workouts in minutes
        /// </summary>
        public double AverageDurationMinutes { get; set; }
        
        /// <summary>
        /// Average calories burned per workout
        /// </summary>
        public double AverageCaloriesBurned { get; set; }
        
        /// <summary>
        /// Distribution of workouts by type
        /// </summary>
        public Dictionary<string, int> WorkoutTypeDistribution { get; set; } = new Dictionary<string, int>();
        
        /// <summary>
        /// Monthly statistics
        /// </summary>
        public List<MonthlyStats> MonthlyStatistics { get; set; } = new List<MonthlyStats>();
    }

    /// <summary>
    /// Class representing monthly workout statistics
    /// </summary>
    public class MonthlyStats
    {
        /// <summary>
        /// Year
        /// </summary>
        public int Year { get; set; }
        
        /// <summary>
        /// Month (1-12)
        /// </summary>
        public int Month { get; set; }
        
        /// <summary>
        /// Number of workouts in this month
        /// </summary>
        public int WorkoutCount { get; set; }
        
        /// <summary>
        /// Total duration of workouts in this month in minutes
        /// </summary>
        public int TotalDuration { get; set; }
        
        /// <summary>
        /// Total calories burned in this month
        /// </summary>
        public int TotalCalories { get; set; }
    }
}