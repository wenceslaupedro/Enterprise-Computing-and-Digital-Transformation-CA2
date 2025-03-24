using System;
using System.Threading.Tasks;
using System.Net.Http;
using FitnessTracker.Services;
using FitnessTracker.Models;

namespace ClientApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Instantiate HttpClient and service
            var httpClient = new HttpClient();
            var workoutService = new WorkoutApiService(httpClient);

            try
            {
                var summary = await workoutService.GetWorkoutSummaryAsync();

                if (summary != null)
                {
                    Console.WriteLine("Workout Summary:");
                    Console.WriteLine($"Total Workouts: {summary.TotalWorkouts}");
                    Console.WriteLine($"Active Days:    {summary.ActiveDays}");
                    Console.WriteLine($"Skipped Days:   {summary.SkippedDays}");
                }
                else
                {
                    Console.WriteLine("No summary received from API.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling the API: {ex.Message}");
            }
        }
    }
}