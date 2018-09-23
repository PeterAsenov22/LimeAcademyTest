namespace MovieTitles
{
    using Newtonsoft.Json;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class MovieTitles
    {
        private const string MainUrl = "https://jsonmock.hackerrank.com/api/movies/search/?Title=";

        public static async Task Main()
        {
            Console.Write("Enter movie title: ");
            string movieTitle = Console.ReadLine();

            List<Movie> movies = await GetMoviesAsync(movieTitle);
            foreach (var movie in movies.OrderBy(m => m.Title))
            {
                Console.WriteLine(movie.Title);
            }
        }

        private static async Task<List<Movie>> GetMoviesAsync(string movieTitle)
        {
            HttpClient httpClient = new HttpClient();
            RequestInfo requestInfo = await RequestMoviesInfoAsync(httpClient, movieTitle, 1);

            List<Movie> allMovies = new List<Movie>();
            foreach (var movie in requestInfo.Movies)
            {
                allMovies.Add(movie);
            }

            if (requestInfo.TotalPages > 1)
            {
                for (int i = 2; i <= requestInfo.TotalPages; i++)
                {
                    requestInfo = await RequestMoviesInfoAsync(httpClient, movieTitle, i);

                    foreach (var movie in requestInfo.Movies)
                    {
                        allMovies.Add(movie);
                    }
                }
            }

            return allMovies;
        }

        private static async Task<RequestInfo> RequestMoviesInfoAsync(HttpClient httpClient, string movieTitle, int page)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{MainUrl}{movieTitle}&page={page}");
            string responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RequestInfo>(responseString);
        }
    }
}
