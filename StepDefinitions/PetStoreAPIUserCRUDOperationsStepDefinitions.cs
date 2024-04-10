using System;
using TechTalk.SpecFlow;
using RestSharp;
using SpecFlowProject1.User;
using NUnit.Framework;
using System.Net;
using NUnit.Framework.Legacy;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    [Category("user")]
    [Order(1)]
    public class PetStoreAPIUserCRUDOperationsStepDefinitions
    {
        UserPayload userPayload = new UserPayload();
        RestResponse response; // Declare response at class level
        private string username;

        [Given(@"I have a valid user payload")]
        public void GivenIHaveAValidUserPayload()
        {
            userPayload.id = "1";
            userPayload.username = "test";
            userPayload.firstName = "test";
            userPayload.lastName = "test";
            userPayload.email = "test@gm.com";
            userPayload.password = "test";
            userPayload.phone = "1234567890";
            userPayload.userStatus = 1;

            username = userPayload.username;
        }

        [When(@"I send a ""([^""]*)"" request to ""([^""]*)"" endpoint")]
        public void WhenISendARequestToEndpoint(string method, string end)
        {
            if (method.Equals("POST"))
            {
                end = "/user";
            }
            else
            {

                end = "/user/" + username;
            }
            var client = new RestClient("https://petstore.swagger.io/v2");

            Method requestMethod;
            switch (method.ToUpper())
            {
                case "POST":
                    requestMethod = Method.Post;
                    break;
                case "GET":
                    requestMethod = Method.Get;
                    break;
                case "PUT":
                    requestMethod = Method.Put;

                    break;
                case "DELETE":
                    requestMethod = Method.Delete;
                    break;
                default:
                    throw new ArgumentException($"Invalid method: {method}");
            }

            var request = new RestRequest(end, requestMethod);
            if (method.Equals("POST"))
                         {
                request.AddJsonBody(userPayload);
            }
            else if (method.Equals("PUT"))
            {
                userPayload.username = "test1";
                username = userPayload.username;
                request.AddJsonBody(userPayload);
            }
            Console.WriteLine(username);
            response = client.Execute(request);
        }

    }
}
