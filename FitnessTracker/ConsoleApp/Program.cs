using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            try
            {
                var apiUrl = "https://localhost:7144/api/workout/summary"; // <-- update if needed
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Workout Summary:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calling the API:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}