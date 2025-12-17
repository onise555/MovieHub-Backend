using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Directors
{
    public class Director
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImg { get; set; }
        public string? Biography { get; set; }  

        public string? Nationality { get; set; }  

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<TvSeries> TvSeries { get; set; } = new List<TvSeries>();
    }
}
