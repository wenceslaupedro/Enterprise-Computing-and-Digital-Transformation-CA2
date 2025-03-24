using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("📦 Starting ClientApp...");

            try
            {
                using var client = new HttpClient();

                // Example: Call an API endpoint (adjust URL as needed)
                var apiUrl = "https://localhost:7144/api/workout/summary"; // Update if needed

                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("✅ Response from API:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error calling the API:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}