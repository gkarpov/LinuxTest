using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AJAXTests.StatusCodeTests
{
    

    [TestFixture]
    public class AJAXStatusCodeTests
    {
        private RestClient client;
        private string jsonToSend;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/");
        }

       
        [Test]
        public void TC_01_StatusCodeTest_GET_LIST_USERS()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_02_StatusCodeTest_GET_SINGLE_USER()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_03_StatusCodeTest_GET_SINGLE_USER_NOT_FOUND()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/23", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void TC_04_StatusCodeTest_GET_LIST_RESURCE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_05_StatusCodeTest_GET_SINGLE_RESOURCE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown/2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_06_StatusCodeTest_GET_SINGLE_RESOURCE_NOT_FOUND()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown/23", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void TC_07_StatusCodeTest_POST_CREATE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users", Method.POST);
            
            // Json to post.
            jsonToSend = "{\n\"name\": \"morpheus\",\n\"job\": \"leader\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void TC_08_StatusCodeTest_PUT_UPDATE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.PUT);
            // Json to post.
            jsonToSend = "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_09_StatusCodeTest_PATCH_UPDATE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.PATCH);

            // Json to post.
            jsonToSend = "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_10_StatusCodeTest_DELETE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.DELETE);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void TC_11_StatusCodeTest_POST_RIGESTER_SUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/register", Method.POST);
            // Json to post.
            jsonToSend = "{\n\"email\": \"sydney @fife\",\n\"password\": \"pistol\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void TC_12_StatusCodeTest_POST_RIGESTER_UNSUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/register", Method.POST);
            // Json to post.
            jsonToSend = "{\n\"email\": \"sydney @fife\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void TC_13_StatusCodeTest_POST_LOGIN_SUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/login", Method.POST);
            // Json to post.
            jsonToSend = "{\n \"email\": \"peter @klaven\",\n\"password\": \"cityslicka\" \n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_14_StatusCodeTest_POST_LOGIN_UNSUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/login", Method.POST);
            // Json to post.
            jsonToSend = "{\n \"email\": \"peter @klaven\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void TC_15_StatusCodeTest_GET_DELAYED_RESP()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?delay=3", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
