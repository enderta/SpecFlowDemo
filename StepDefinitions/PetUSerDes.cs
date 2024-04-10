using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    internal class PetUSerDes
    {
        [Test]
        public async Task TestMethod()
        {
            var options = new RestClientOptions("https://petstore.swagger.io")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/v2/user/test1", Method.Get);

            var response = await client.ExecuteAsync<PetUser>(request);
            if (response.IsSuccessful)
            {
                var data = response.Data;
                if (data != null)
                {
                    Console.WriteLine(data.id);
                    Console.WriteLine(data.username);
                    Console.WriteLine(data.firstName);
                    Console.WriteLine(data.lastName);
                    Console.WriteLine(data.email);
                    Console.WriteLine(data.password);
                    Console.WriteLine(data.phone);
                    Console.WriteLine(data.userStatus);
                }
            }
          
        }


    }
}
