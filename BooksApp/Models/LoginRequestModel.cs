namespace BooksApp.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class LoginRequestModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("passHash")]
        public string Password { get; set; }
    }
}