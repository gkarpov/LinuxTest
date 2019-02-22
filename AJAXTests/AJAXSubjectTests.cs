using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AJAXTests
{
    [TestFixture]
    public class AJAXSubjectTests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/");
        }



        [Test]
        public void SubjectTest_GET_SINGLE_USER()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_GET_LIST_USERS()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_GET_SINGLE_USER_NOT_FOUND()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/23", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void SubjectTest_GET_LIST_RESURCE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_GET_SINGLE_RESOURCE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown/2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_GET_SINGLE_RESOURCE_NOT_FOUND()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown/23", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void SubjectTest_POST_CREATE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users", Method.POST);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void SubjectTest_PUT_UPDATE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.PUT);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_PATCH_UPDATE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.PATCH);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_DELETE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.DELETE);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void SubjectTest_POST_RIGESTER_SUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/register", Method.POST);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void SubjectTest_POST_RIGESTER_UNSUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/register", Method.POST);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void SubjectTest_POST_LOGIN_SUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/login", Method.POST);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SubjectTest_POST_LOGIN_UNSUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/login", Method.POST);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void SubjectTest_GET_DELAYED_RESP()
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
