using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDBAPI.Models;

namespace MovieShow.Models
{
    public class MovieResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public IList<Movie> Results { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
