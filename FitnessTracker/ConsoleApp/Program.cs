using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FitnessTracker.Services;
using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Set up dependency injection
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHttpClient<WorkoutApiService>();
                })
                .Build();

            // Resolve the WorkoutApiService
            var service = host.Services.GetRequiredService<WorkoutApiService>();

            try
            {
                var summary = await service.GetWorkoutSummaryAsync();

                if (summary != null)
                {
                    Console.WriteLine("Workout Summary:");
                    Console.WriteLine($"Total Workouts: {summary.TotalWorkouts}");
                    Console.WriteLine($"Active Days: {summary.ActiveDays}");
                    Console.WriteLine($"Skipped Days: {summary.SkippedDays}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve workout summary.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling API: {ex.Message}");
            }
        }
    }
}