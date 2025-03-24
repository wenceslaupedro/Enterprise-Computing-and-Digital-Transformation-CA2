using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public class WorkoutApiService
    {
        private readonly HttpClient _httpClient;

        public WorkoutApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WorkoutSummary> GetWorkoutSummaryAsync()
        {
            try
            {
                var apiUrl = "http://localhost:5190/api/workout/summary"; // Match your running backend port
                var summary = await _httpClient.GetFromJsonAsync<WorkoutSummary>(apiUrl);
                return summary;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API error: {ex.Message}");
                throw;
            }
        }
    }
}