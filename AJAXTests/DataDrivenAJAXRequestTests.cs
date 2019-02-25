using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AJAXtests.DataDrivenAJAXRequestTests
{
    class DataDrivenAJAXRequestTests
    {
        [TestFixture]
        public class AJAXReqestTests
        {
            private RestClient client;
            private string jsonToSend;

            [SetUp]
            public void Setup()
            {
                client = new RestClient("https://reqres.in/");
            }


            [TestCase("/api/users?page=2", Method.GET, HttpStatusCode.OK, TestName = "Test 1")]
            [TestCase("/api/users", Method.POST, HttpStatusCode.Created, "{\n\"name\": \"morpheus\",\n\"job\": \"leader\"\n}", TestName = "Test 2")]
            public void StatusCodeTest(string req, Method metd, HttpStatusCode codeExpected, string json ="")
            {
                // arrange
                RestRequest request = new RestRequest(req, metd);
                // Json to post.
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
                // act
                IRestResponse response = client.Execute(request);

                // assert
                Assert.That(response.StatusCode, Is.EqualTo(codeExpected));
            }

        }
    }
}