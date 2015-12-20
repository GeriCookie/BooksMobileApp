namespace BooksApp.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class LoginResponseModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("authKey")]
        public string AuthKey { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}