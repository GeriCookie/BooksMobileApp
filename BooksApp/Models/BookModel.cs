using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    [JsonObject]
    public class BookModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

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
