using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            try
            {
                var apiUrl = "http://localhost:5190/api/workout/summary";
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