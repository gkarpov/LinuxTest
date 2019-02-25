using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AJAXTests.DataEntities;
using Newtonsoft.Json;
using System.Globalization;

namespace AJAXTests.SubjectTests
{


    [TestFixture]
    public class AJAXSubjectTests
    {
        private RestClient client;
        private string TimeCreated;
        private DateTime TimeCreated_dt;
        private DateTime TimeNow;
        private string jsonToSend;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/");
        }

        [Test]
        public void TC_01_01_SubjectTest_GET_LIST_USERS_TotalPages()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.TotalPages, Is.EqualTo("4"));
        }

        [Test]
        public void TC_01_02_SubjectTest_GET_LIST_USERS_FirstElement_FirstName()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).FirstaName, Is.EqualTo("Eve"));
        }

        [Test]
        public void TC_01_03_SubjectTest_GET_LIST_USERS_id_FirstName()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).FirstaName, Is.EqualTo("Eve"));
            Assert.That(userResponse.Data.ElementAt(0).Id, Is.EqualTo("4"));
        }

        [Test]
        public void TC_02_01_SubjectTest_GET_SINGLE_USER()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            SingleUserResponse userResponse =
                JsonConvert.DeserializeObject<SingleUserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.FirstaName, Is.EqualTo("Janet"));
        }
        
        [Test]
        public void TC_03_01_SubjectTest_GET_SINGLE_USER_NOT_FOUND()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/23", Method.GET);

            // act
            IRestResponse response = client.Execute(request);


            // assert
            Assert.That(response.Content, Is.EqualTo("{}"));
        }

        [Test]
        public void TC_04_01_SubjectTest_GET_LIST_RESOURCE_TotalPages()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.TotalPages, Is.EqualTo("4"));
        }

        [Test]
        public void TC_04_02_SubjectTest_GET_LIST_RESOURCE_FirstElement_Name()
        {
            // arrange
            RestRequest request = new RestRequest("/api/uknown", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).Name, Is.EqualTo("cerulean"));
        }

        [Test]
        public void TC_04_03_SubjectTest_GET_LIST_RESOURCE_id_Name()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).Name, Is.EqualTo("cerulean"));
            Assert.That(userResponse.Data.ElementAt(0).Id, Is.EqualTo("1"));
        }
        [Test]
        public void TC_05_01_SubjectTest_GET_SINGLE_RESOURCE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown/2", Method.GET);

            // act
            IRestResponse response = client.Execute(request);
            SingleUserResponse userResponse =
                JsonConvert.DeserializeObject<SingleUserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.Name, Is.EqualTo("fuchsia rose"));
        }

        [Test]
        public void TC_06_01_SubjectTest_GET_SINGLE_RESOURCE_NOT_FOUND()
        {
            // arrange
            RestRequest request = new RestRequest("/api/unknown/23", Method.GET);

            // act
            IRestResponse response = client.Execute(request);
            
            // assert
            Assert.That(response.Content, Is.EqualTo("{}"));
        }

        [Test]
        public void TC_07_01_SubjectTest_POST_CREATE_Day()
        {
            
            // arrange
            RestRequest request = new RestRequest("/api/users", Method.POST);

            // Json to post.
            jsonToSend = "{\n\"name\": \"morpheus\",\n\"job\": \"leader\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);

            UserData userResponse =
            JsonConvert.DeserializeObject<UserData>(response.Content);

            // assert
            //Assert.That(userResponse.Name, Is.EqualTo("morpheus"));
            //Assert.That(userResponse.Job, Is.EqualTo("leader"));
            //Assert.That(userResponse.Id, Is.EqualTo("14"));
            TimeCreated = userResponse.CreatedAt;
            TimeCreated_dt = DateTime.ParseExact(TimeCreated, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

            TimeNow = DateTime.Now;
            Assert.That(TimeNow.Date, Is.EqualTo(TimeCreated_dt.Date));
            //Assert.That(TimeNow.Hour, Is.EqualTo(TimeCreated_dt.Hour));
            //Assert.That(TimeNow.Minute, Is.EqualTo(TimeCreated_dt.Minute));
        }

        [Test]
        public void TC_08_01_SubjectTest_PUT_UPDATE_Day()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.PUT);
            // Json to post.
            jsonToSend = "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);

            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);
            // assert

            TimeCreated = userResponse.UpdatedAt;
            TimeCreated_dt = DateTime.ParseExact(TimeCreated, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

            TimeNow = DateTime.Now;
            Assert.That(TimeNow.Date, Is.EqualTo(TimeCreated_dt.Date));

        }

        [Test]
        public void TC_09_01_SubjectTest_PATCH_UPDATE_Day()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.PATCH);
            // Json to post.
            jsonToSend = "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);

            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);
            
            // assert

            TimeCreated = userResponse.UpdatedAt;
            TimeCreated_dt = DateTime.ParseExact(TimeCreated, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

            TimeNow = DateTime.Now;
            Assert.That(TimeNow.Date, Is.EqualTo(TimeCreated_dt.Date));

        }

        [Test]
        public void TC_10_01_SubjectTest_DELETE()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users/2", Method.DELETE);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.Content, Is.Empty);
        }

        [Test]
        public void TC_11_01_SubjectTest_POST_RIGESTER_SUC_TokenLength()
        {
            // arrange
            RestRequest request = new RestRequest("/api/register", Method.POST);

            // Json to post.
            jsonToSend = "{\n\"email\": \"sydney @fife\",\n\"password\": \"pistol\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);
            RegisterEntry userResponse =
                            JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert

            Assert.That(userResponse.Token.Length, Is.EqualTo(16));


        }

        [Test]
        public void TC_12_01_SubjectTest_POST_RIGESTER_UNSUC_ErrorMessage()
        {
            // arrange
            RestRequest request = new RestRequest("/api/register", Method.POST);
            
            // Json to post.
            jsonToSend = "{\n\"email\": \"sydney @fife\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);
            RegisterEntry userResponse =
                            JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert

            Assert.That(userResponse.Error, Is.EqualTo("Missing password"));
        }

        [Test]
        public void TC_13_01_SubjectTest_POST_LOGIN_SUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/login", Method.POST);
            // Json to post.
            jsonToSend = "{\n \"email\": \"peter @klaven\",\n\"password\": \"cityslicka\" \n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);
            
            RegisterEntry userResponse =
                            JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert

            Assert.That(userResponse.Token, Is.EqualTo("QpwL5tke4Pnpja7X"));
        }

        [Test]
        public void TC_14_01_SubjectTest_POST_LOGIN_UNSUC()
        {
            // arrange
            RestRequest request = new RestRequest("/api/login", Method.POST);
            // Json to post.
            jsonToSend = "{\n\"email\": \"sydney @fife\"\n}";

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // act
            IRestResponse response = client.Execute(request);
            RegisterEntry userResponse =
                            JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert

            Assert.That(userResponse.Error, Is.EqualTo("Missing password"));
        }

        [Test]
        public void TC_15_01_SubjectTest_GET_DELAYED_RESP()
        {
            // arrange
            RestRequest request = new RestRequest("/api/users?delay=3", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).FirstaName, Is.EqualTo("George"));
            Assert.That(userResponse.Data.ElementAt(0).Id, Is.EqualTo("1"));

        }
    }
}
