using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Countres
{
    public class Country
    {
        public int Id { get; set; } 

        public string CountryName { get; set; }

        public string CountryImg {  get; set; } 

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public List<TvSeries> TvSeries { get; set; } = new List<TvSeries>();

    }
}
