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
   					Console.WriteLine();
    				Console.WriteLine("+----------------+--------------+");
    				Console.WriteLine("|     Metric     |    Value     |");
    				Console.WriteLine("+----------------+--------------+");
    				Console.WriteLine($"| Total Workouts | {summary.TotalWorkouts,12} |");
    				Console.WriteLine($"| Active Days    | {summary.ActiveDays,12} |");
    				Console.WriteLine($"| Skipped Days   | {summary.SkippedDays,12} |");
    				Console.WriteLine("+----------------+--------------+");
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