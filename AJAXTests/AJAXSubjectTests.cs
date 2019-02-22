//using NUnit.Framework;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace AJAXTests
//{
//    [TestFixture]
//    public class AJAXSubjectTests
//    {
//        private RestClient client;

//        [SetUp]
//        public void Setup()
//        {
//            RestClient client = new RestClient("https://reqres.in/");
//        }



//        [Test]
//        public void StatusCodeTest_GET_SINGLE_USER()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_LIST_USERS()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_SINGLE_USER()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_SINGLE_USER_NOT_FOUND()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_LIST_RESURCE()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_SINGLE_RESOURCE()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_SINGLE_RESOURCE_NOT_FOUND()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users/2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_POST_CREATE()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_PUT_UPDATE()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_PATCH_UPDATE()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users/2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_DELETE()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_POST_RIGESTER_SUC()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_POST_RIGESTER_UNSUC()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users/2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_POST_LOGIN_SUC()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_POST_LOGIN_UNSUC()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users/2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }

//        [Test]
//        public void StatusCodeTest_GET_DELAYED_RESP()
//        {
//            // arrange
//            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

//            // act
//            IRestResponse response = client.Execute(request);

//            // assert
//            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//        }
//    }
//}
