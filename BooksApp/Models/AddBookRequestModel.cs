namespace BooksApp.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class AddBookRequestModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Genres { get; set; }
        
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public int? Pages { get; set; }

        [JsonProperty("coverUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverUrl { get; set; }
    }
}