using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AJAXtests.DataDrivenAJAXStatusCodeTests
{
        [TestFixture]
        public class AJAXReqestTests
        {
            private RestClient client;
            private string jsonToSend; // JSON request body

            [SetUp]
            public void Setup()
            {
                client = new RestClient("https://reqres.in/");
            }


            [TestCase("/api/users?page=2", Method.GET, HttpStatusCode.OK, TestName = "TestCase 01: GET - LIST USERS")]
            [TestCase("/api/users/2", Method.GET, HttpStatusCode.OK, TestName = "TestCase 02: GET - SINGLE USER")]
            [TestCase("/api/users/23", Method.GET, HttpStatusCode.NotFound, TestName = "TestCase 03: GET - SINGLE USER - NOT FOUND")]
            [TestCase("/api/unknown/", Method.GET, HttpStatusCode.OK, TestName = "TestCase 04: GET - LIST <RESOURCE>")]
            [TestCase("/api/unknown/2", Method.GET, HttpStatusCode.OK, TestName = "TestCase 05: GET - SINGLE <RESOURCE>")]
            [TestCase("/api/unknown/23", Method.GET, HttpStatusCode.NotFound, TestName = "TestCase 06: GET - SINGLE <RESOURCE> - NOT FOUND")]
            [TestCase("/api/users", Method.POST, HttpStatusCode.Created, "{\n\"name\": \"morpheus\",\n\"job\": \"leader\"\n}",TestName = "TestCase 07: POST - CREATE")]
            [TestCase("/api/users/2", Method.PUT, HttpStatusCode.OK, "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}", TestName = "TestCase 08: PUT - UPDATE")]
            [TestCase("/api/users/2", Method.PATCH, HttpStatusCode.OK, "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}", TestName = "TestCase 09: PATCH - UPDATE")]
            [TestCase("/api/users/2", Method.DELETE, HttpStatusCode.NoContent, TestName = "TestCase 10: DELETE")]
            [TestCase("/api/register", Method.POST, HttpStatusCode.Created, "{\n\"email\": \"sydney @fife\",\n\"password\": \"pistol\"\n}", TestName = "TestCase 11: POST - REGISTER - SUCCESFUL")]
            [TestCase("/api/register", Method.POST, HttpStatusCode.BadRequest, "{\n\"email\": \"sydney @fife\"\n}", TestName = "TestCase 12: POST - REGISTER - UNSUCCESFUL")]
            [TestCase("/api/login", Method.POST, HttpStatusCode.OK, "{\n \"email\": \"peter @klaven\",\n\"password\": \"cityslicka\" \n}", TestName = "TestCase 13: POST - LOGIN - SUCCESFUL")]
            [TestCase("/api/login", Method.POST, HttpStatusCode.BadRequest, "{\n \"email\": \"peter @klaven\"\n}", TestName = "TestCase 14: POST - LOGIN - UNSUCCESFUL")]
            [TestCase("/api/users?delay=3", Method.GET, HttpStatusCode.OK, TestName = "TestCase 15: GET - DELAYED RESPONSE")]
            public void StatusCodeTest(string req, Method metd, HttpStatusCode codeExpected, string jsonReqBody = "")
            {
                // arrange
                RestRequest request = new RestRequest(req, metd);
                // Adding JSON request body.
                request.AddParameter("application/json; charset=utf-8", jsonReqBody, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
                
                // act
                IRestResponse response = client.Execute(request);

                // assert
                Assert.That(response.StatusCode, Is.EqualTo(codeExpected));
            }

        }
    
}