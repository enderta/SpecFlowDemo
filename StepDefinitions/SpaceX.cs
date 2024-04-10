using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    internal class SpaceX
    {


        RestResponse response;
        [When(@"I send a GET request to ""(.*)"" spacex")]
        public async Task WhenISendAGETRequestToSpacex(string endpoint)
        {
            var options = new RestClientOptions("https://api.spacexdata.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(endpoint, Method.Get);
            response = await client.ExecuteAsync(request);

            var content = response.Content;
            var deserializedContent = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);

            if (deserializedContent != null && deserializedContent.Count > 0 && deserializedContent[0].ContainsKey("flight_number"))
            {
                Console.WriteLine(deserializedContent[0]["flight_number"]);
            }
            else
            {
                Console.WriteLine("The response content could not be deserialized into the expected format.");
            }
            client.Get<List<Dictionary<string, object>>>(request);


        }

        [Then(@"The response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            if (response != null)
            {
                ClassicAssert.AreEqual(statusCode, (int)response.StatusCode);
            }
            else
            {
                Console.WriteLine("The response object is null.");
            }
        }
    }
}
    
   
