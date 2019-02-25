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

        private IRestResponse GetResponse(RestClient client, string req, Method metd, HttpStatusCode codeExpected, string jsonReqBody = "")
        {

            RestRequest rReq = new RestRequest(req, metd);
            // Adding JSON request body.
            rReq.AddParameter("application/json; charset=utf-8", jsonReqBody, ParameterType.RequestBody);
            rReq.RequestFormat = DataFormat.Json;

            return  client.Execute(rReq);
        }



        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/");
        }

        [Test]
        public void TC_01_01_SubjectTest_GET_LIST_USERS_TotalPages()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users?page=2", Method.GET, HttpStatusCode.OK);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);
            
            // assert
            Assert.That(userResponse.TotalPages, Is.EqualTo("4"));
        }

        [Test]
        public void TC_01_02_SubjectTest_GET_LIST_USERS_FirstElement_FirstName()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users?page=2", Method.GET, HttpStatusCode.OK);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);
            
            // assert
            Assert.That(userResponse.Data.ElementAt(0).FirstaName, Is.EqualTo("Eve"));
        }

        [Test]
        public void TC_01_03_SubjectTest_GET_LIST_USERS_id_FirstName()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users?page=2", Method.GET, HttpStatusCode.OK);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);
            
            // assert
            Assert.That(userResponse.Data.ElementAt(0).FirstaName, Is.EqualTo("Eve"));
            Assert.That(userResponse.Data.ElementAt(0).Id, Is.EqualTo("4"));
        }

        [Test]
        public void TC_02_01_SubjectTest_GET_SINGLE_USER()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/2", Method.GET, HttpStatusCode.OK);
            SingleUserResponse userResponse =
                JsonConvert.DeserializeObject<SingleUserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.FirstaName, Is.EqualTo("Janet"));
        }

        [Test]
        public void TC_03_01_SubjectTest_GET_SINGLE_USER_NOT_FOUND()
        {


            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/23", Method.GET, HttpStatusCode.NotFound);

            // assert
            Assert.That(response.Content, Is.EqualTo("{}"));
        }

        [Test]
        public void TC_04_01_SubjectTest_GET_LIST_RESOURCE_TotalPages()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/unknown", Method.GET, HttpStatusCode.OK);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.TotalPages, Is.EqualTo("4"));
        }

        [Test]
        public void TC_04_02_SubjectTest_GET_LIST_RESOURCE_FirstElement_Name()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/unknown", Method.GET, HttpStatusCode.OK);
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

            //arrange+act
            IRestResponse response = GetResponse(client, "/api/unknown", Method.GET, HttpStatusCode.OK);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).Name, Is.EqualTo("cerulean"));
            Assert.That(userResponse.Data.ElementAt(0).Id, Is.EqualTo("1"));
        }

        [Test]
        public void TC_05_01_SubjectTest_GET_SINGLE_RESOURCE()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/unknown/2", Method.GET, HttpStatusCode.OK);
            SingleUserResponse userResponse =
                JsonConvert.DeserializeObject<SingleUserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.Name, Is.EqualTo("fuchsia rose"));
        }

        [Test]
        public void TC_06_01_SubjectTest_GET_SINGLE_RESOURCE_NOT_FOUND()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/unknown/23", Method.GET, HttpStatusCode.NotFound);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(response.Content, Is.EqualTo("{}"));
        }

        [Test]
        public void TC_07_01_SubjectTest_POST_CREATE_Name_Job()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users", Method.POST, HttpStatusCode.Created, "{\n\"name\": \"morpheus\",\n\"job\": \"leader\"\n}");
            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);

            // assert
            Assert.That(userResponse.Name, Is.EqualTo("morpheus"));
            Assert.That(userResponse.Job, Is.EqualTo("leader"));

        }

        [Test]
        public void TC_07_02_SubjectTest_POST_CREATE_Day()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users", Method.POST, HttpStatusCode.Created, "{\n\"name\": \"morpheus\",\n\"job\": \"leader\"\n}");
            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);

            TimeCreated = userResponse.CreatedAt;
            TimeCreated_dt = DateTime.ParseExact(TimeCreated, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
            TimeNow = DateTime.Now;

            // assert
            Assert.That(TimeNow.Date, Is.EqualTo(TimeCreated_dt.Date));
        }

        [Test]
        public void TC_08_01_SubjectTest_PUT_UPDATE_Name_Job()
        {

            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/2", Method.PUT, HttpStatusCode.OK, "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}");
            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);

            // assert
            Assert.That(userResponse.Name, Is.EqualTo("morpheus"));
            Assert.That(userResponse.Job, Is.EqualTo("zion resident"));

        }

        [Test]
        public void TC_08_02_SubjectTest_PUT_UPDATE_Day()
        {

            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/2", Method.PUT, HttpStatusCode.OK, "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}");
            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);

            TimeCreated = userResponse.UpdatedAt;
            TimeCreated_dt = DateTime.ParseExact(TimeCreated, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);            
            TimeNow = DateTime.Now;   
            
            // assert
            Assert.That(TimeNow.Date, Is.EqualTo(TimeCreated_dt.Date));

        }

        [Test]
        public void TC_09_01_SubjectTest_PATCH_UPDATE_Name_Job()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/2", Method.PATCH, HttpStatusCode.OK, "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}");
            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);

            // assert
            Assert.That(userResponse.Name, Is.EqualTo("morpheus"));
            Assert.That(userResponse.Job, Is.EqualTo("zion resident")); ;

        }

        [Test]
        public void TC_09_02_SubjectTest_PATCH_UPDATE_Day()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/2", Method.PATCH, HttpStatusCode.OK, "{\n\"name\": \"morpheus\",\n\"job\": \"zion resident\"\n}");
            UserData userResponse =
                JsonConvert.DeserializeObject<UserData>(response.Content);

            TimeCreated = userResponse.UpdatedAt;
            TimeCreated_dt = DateTime.ParseExact(TimeCreated, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

            TimeNow = DateTime.Now;
            
            // assert
            Assert.That(TimeNow.Date, Is.EqualTo(TimeCreated_dt.Date));

        }

        [Test]
        public void TC_10_01_SubjectTest_DELETE()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users/2", Method.DELETE, HttpStatusCode.NoContent);

            // assert
            Assert.That(response.Content, Is.Empty);
        }

        [Test]
        public void TC_11_01_SubjectTest_POST_RIGESTER_SUC_TokenLength()
        {

            //arrange+act
            IRestResponse response = GetResponse(client, "/api/register", Method.POST, HttpStatusCode.Created, "{\n\"email\": \"sydney @fife\",\n\"password\": \"pistol\"\n}");
            RegisterEntry userResponse =
                JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert
            Assert.That(userResponse.Token.Length, Is.EqualTo(16));
            
        }

        [Test]
        public void TC_12_01_SubjectTest_POST_RIGESTER_UNSUC_ErrorMessage()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/register", Method.POST, HttpStatusCode.BadRequest, "{\n\"email\": \"sydney @fife\"\n}");
            RegisterEntry userResponse =
                JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert
            Assert.That(userResponse.Error, Is.EqualTo("Missing password"));
        }

        [Test]
        public void TC_13_01_SubjectTest_POST_LOGIN_SUC()
        {

            //arrange+act
            IRestResponse response = GetResponse(client, "/api/login", Method.POST, HttpStatusCode.Created, "{\n \"email\": \"peter @klaven\",\n\"password\": \"cityslicka\" \n}");
            RegisterEntry userResponse =
                JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert
            Assert.That(userResponse.Token, Is.EqualTo("QpwL5tke4Pnpja7X"));
        }

        [Test]
        public void TC_14_01_SubjectTest_POST_LOGIN_UNSUC()
        {

            //arrange+act
            IRestResponse response = GetResponse(client, "/api/register", Method.POST, HttpStatusCode.BadRequest, "{\n\"email\": \"sydney @fife\"\n}");
            RegisterEntry userResponse =
                JsonConvert.DeserializeObject<RegisterEntry>(response.Content);

            // assert
            Assert.That(userResponse.Error, Is.EqualTo("Missing password"));
        }

        [Test]
        public void TC_15_01_SubjectTest_GET_DELAYED_RESP()
        {
            //arrange+act
            IRestResponse response = GetResponse(client, "/api/users?page=2", Method.GET, HttpStatusCode.OK);
            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            // assert
            Assert.That(userResponse.Data.ElementAt(0).FirstaName, Is.EqualTo("Eve"));
            Assert.That(userResponse.Data.ElementAt(0).Id, Is.EqualTo("4"));
        }


    }

  
}
