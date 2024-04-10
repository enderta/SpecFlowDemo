using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
    internal class FakeStroe
    {
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Before()
        {
            var options = new RestClientOptions("https://fakestoreapi.com")
            {
                MaxTimeout = -1,
            };
            client = new RestClient(options);
        }

        [TearDown]
        public void After()
        {
            // Clean up
        }

        [Test]
        public async Task CRUD()
        {
            request = new RestRequest("/products/", Method.Get);
            var response = await client!.ExecuteAsync(request);
            var data = response.Content;
            ClassicAssert.AreEqual(200, (int)response.StatusCode);
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data);
            ClassicAssert.AreEqual("1", lst[0]["id"].ToString());
            //post 
            request = new RestRequest("/products/", Method.Post);
            request.AddJsonBody(new { title = "test", price = 10, description = "test", category = "test", image = "test" });
            response = await client.ExecuteAsync(request);
            data = response.Content;
            ClassicAssert.AreEqual(200, (int)response.StatusCode);
            var id= Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(data)["id"].ToString();
            //put
            request = new RestRequest("/products/"+id, Method.Put);
            request.AddJsonBody(new { title = "test", price = 10, description = "test", category = "test", image = "test" });
            response = await client.ExecuteAsync(request);
            data = response.Content;
            ClassicAssert.AreEqual(200, (int)response.StatusCode);
            //delete
            request = new RestRequest("/products/" + id, Method.Delete);
            response = await client.ExecuteAsync(request);
            data = response.Content;
            ClassicAssert.AreEqual(200, (int)response.StatusCode);

        }
    }
    }

