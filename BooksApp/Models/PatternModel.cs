namespace BooksApp.Models
{
    using Newtonsoft.Json;
    using SQLite.Net.Attributes;

    public class PatternModel
    {
        [Indexed(Unique = true)]
        public string Pattern { get; set; }
    }
}