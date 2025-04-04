namespace WorkoutTracker.Services
{
    /// 
    /// Class representing analysis of a user's workout history
    /// 
    public class WorkoutAnalysis
    {
        /// 
        /// Total number of workouts completed
        /// 
        public int TotalWorkouts { get; set; }

        /// 
        /// Total duration of all workouts in minutes
        /// 
        public int TotalDurationMinutes { get; set; }

        /// 
        /// Total calories burned across all workouts
        /// 
        public int TotalCaloriesBurned { get; set; }

        /// 
        /// Average duration of workouts in minutes
        /// 
        public double AverageDurationMinutes { get; set; }

        /// 
        /// Average calories burned per workout
        /// 
        public double AverageCaloriesBurned { get; set; }

        /// 
        /// Distribution of workouts by type
        /// 
        public Dictionary<string, int> WorkoutTypeDistribution { get; set; } = new Dictionary<string, int>();

        /// 
        /// Monthly statistics
        /// 
        public List<MonthlyStats> MonthlyStatistics { get; set; } = new List<MonthlyStats>();
    }

    /// 
    /// Class representing monthly workout statistics
    /// 
    public class MonthlyStats
    {
        /// 
        /// Year
        /// 
        public int Year { get; set; }

        /// 
        /// Month (1-12)
        /// 
        public int Month { get; set; }

        /// 
        /// Number of workouts in this month
        /// 
        public int WorkoutCount { get; set; }

        /// 
        /// Total duration of workouts in this month in minutes
        /// 
        public int TotalDuration { get; set; }

        /// 
        /// Total calories burned in this month
        /// 
        public int TotalCalories { get; set; }
    }
}