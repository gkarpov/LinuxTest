using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AJAXTests.DataEntities
{
    class UserResponse
    {
        [JsonProperty("page")]
        public string Page { get; set; }
        [JsonProperty("per_page")]
        public string PerPage { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("total_pages")]
        public string TotalPages { get; set; }
        [JsonProperty("data")]
        public List<UserData> Data { get; set; }
    }

    class SingleUserResponse
    {
        [JsonProperty("data")]
        public UserData Data { get; set; }
    }

    class RegisterEntry
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
