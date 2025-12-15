using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Genres
{
    public class Genre
    {
        public int Id { get; set; } 

        public string GenreName { get; set; }   

        public string GenreImg {  get; set; }
   
        public List<Movie> movies { get; set; } = new List<Movie>();

        public List<TvSeries> tvSeries { get; set; } = new List<TvSeries>();    


    }
}
