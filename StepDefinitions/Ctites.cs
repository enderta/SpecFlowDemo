using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    internal class Ctites
    {
        private static string token;

        [SetUp]
        public void Before()
        {
            /* ChromeOptions options = new ChromeOptions();
             options.AddArgument("--disable-notifications");
             IWebDriver driver = new ChromeDriver(options);

             // Open the desired webpage
             driver.Navigate().GoToUrl("https://dashboard.qa.codeyourfuture.io/");

             // Execute JavaScript to retrieve token from local storage
             IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
             token = (string)js.ExecuteScript("return localStorage.getItem('token');");

             // Output the retrieved token
             Console.WriteLine("Token from local storage: " + token);

             // Close the WebDriver
             driver.Quit();*/
            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NTFlZDNjYmY2MWFiNjY4YTQzMzc3NTQiLCJmdWxsTmFtZSI6IkVuZGVyIFRhbnJpdmVyZGkiLCJlbWFpbCI6ImVuZGVydGFudmVyQGdtYWlsLmNvbSIsImFkbWluIjp0cnVlLCJjaXR5SWQiOiI1Y2VmYTY3YzA3MWQyMTAwMThlM2RjY2YiLCJzdXBlckFkbWluIjp0cnVlLCJyb2xlcyI6WyJDSVRZX0FETUlOUyIsIkFQUExJQ0FOVFNfREFUQSIsIlNURVBTX1JFVklFVyIsIkVYUEVOU0VTIiwiRVZFTlRTIiwiQ09IT1JUX1BMQU5ORVIiLCJDQUxMUyIsIkdMT0JBTF9BQ0NFU1MiXSwiaWF0IjoxNzEyMTY1NTQ4LCJleHAiOjE3MTIxNzI3NDh9.MT7JxoT6AuHzqi1pHSluiZcf-cPZJQD-YIRfO8N7IlY";
        }

        [Test]
        public async Task GetCities()
        {
            var options = new RestClientOptions("https://cyf-api.qa.codeyourfuture.io")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/cities", Method.Get);
            request.AddHeader("Authorization", "Bearer " + token);
            var response = await client.ExecuteAsync<CitiesObj.Root>(request);
            if (response.IsSuccessful)
            {
                var data = response.Data;
                if (data != null)
                {
                    foreach (var city in data.cities)
                    {
                        Console.WriteLine(city._id);
                        Console.WriteLine(city.name);
                        // Other properties can be accessed similarly
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
            }
        }
        [Test]
        public async Task GetRegions()
        {
            var options = new RestClientOptions("https://cyf-api.qa.codeyourfuture.io")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/regions", Method.Get);
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NTFlZDNjYmY2MWFiNjY4YTQzMzc3NTQiLCJmdWxsTmFtZSI6IkVuZGVyIFRhbnJpdmVyZGkiLCJlbWFpbCI6ImVuZGVydGFudmVyQGdtYWlsLmNvbSIsImFkbWluIjp0cnVlLCJjaXR5SWQiOiI1Y2VmYTY3YzA3MWQyMTAwMThlM2RjY2YiLCJzdXBlckFkbWluIjp0cnVlLCJyb2xlcyI6WyJDSVRZX0FETUlOUyIsIkFQUExJQ0FOVFNfREFUQSIsIlNURVBTX1JFVklFVyIsIkVYUEVOU0VTIiwiRVZFTlRTIiwiQ09IT1JUX1BMQU5ORVIiLCJDQUxMUyIsIkdMT0JBTF9BQ0NFU1MiXSwiaWF0IjoxNzEyMzM1MzAwLCJleHAiOjE3MTIzNDI1MDB9.RuXDxArRhE2AIUPjWVE1g77Evp7TReLDIhVNu9BO5Ug");
            var response = await client.ExecuteAsync<Regions.AllRegions>(request);
            string expected = "Remote";
            if (response.IsSuccessful)
            {
                Assert.That(response.IsSuccessful, Is.True);
                Console.Out.WriteLineAsync(((int)response.StatusCode).ToString());
                var data = response.Data;
                data.regions.ForEach(region => Console.WriteLine(region.name));
                int count = data.regions.Count;
                Console.WriteLine(count);
                if (data != null)
                {

                    foreach (var region in data.regions)
                    {
                        Assert.That(region.name, Is.EqualTo(expected));
                        break;
                    }
                }
            }
            else
            {
                Assert.That(response.IsSuccessful, Is.True);
                Console.Out.WriteLineAsync(((int)response.StatusCode).ToString());
                Console.WriteLine($"Error: {response.ErrorMessage}");
            }
        }

    }
}
