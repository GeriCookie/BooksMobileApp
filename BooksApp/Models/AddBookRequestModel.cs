namespace BooksApp.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class AddBookRequestModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("genres")]
        public IEnumerable<string> Genres { get; set; }

        [JsonProperty("ratings")]
        public int? Rating { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pages")]
        public int? Pages { get; set; }

        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }
    }
}