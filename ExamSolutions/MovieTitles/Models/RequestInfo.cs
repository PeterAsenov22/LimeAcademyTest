namespace MovieTitles.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject]
    public class RequestInfo
    {
        [JsonProperty("total")]
        public int TotalMovies { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("per_page")]
        public int MoviesPerPage { get; set; }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("data")]
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
