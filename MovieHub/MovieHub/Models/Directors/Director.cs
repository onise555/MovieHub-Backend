using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Directors
{
    public class Director
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<TvSeries> TvSeries { get; set; } = new List<TvSeries>();
    }
}
