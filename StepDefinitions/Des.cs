using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json;

namespace SpecFlowProject1.StepDefinitions
{
    [TestFixture]
    internal class Des
    {
        [Test]
        public async Task TestMethod()
        {
            var options = new RestClientOptions("https://api.spacexdata.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/v3/launches/upcoming", Method.Get);
            var response = await client.ExecuteAsync<List<Root>>(request);
            if (response.IsSuccessful)
            {
                var data = response.Data;
                if (data != null)
                {
                    foreach (var item in data.Where(d => d.rocket != null && d.rocket.first_stage != null && d.rocket.first_stage.cores.Any()))
                    {
                        Console.WriteLine(item.rocket.rocket_id);
                        Console.WriteLine(item.rocket.first_stage.cores[0].flight);
                        Console.WriteLine($"Flight Number: {item.flight_number}");
                        Console.WriteLine($"Mission Name: {item.mission_name}");
                        // Other properties can be accessed similarly
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
            }
        }
    }
}

