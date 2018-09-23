namespace MovieTitles.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class Movie
    {
        public string Title { get; set; }
    }
}
