using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    [JsonObject]
    public class UpdateModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string UpdateText { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }
}
