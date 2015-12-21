using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    [JsonObject]
    public class ChangeStatusRequestModel
    {
        [JsonProperty("bookId")]
        public string BookId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
