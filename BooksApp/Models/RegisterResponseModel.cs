namespace BooksApp.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class RegisterResponseModel
    {
        [JsonProperty("err")]
        public string Error { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("authKey")]
        public string AuthKey { get; set; }
    }
}