using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Actors
{
    public class Actor
    {
        public int Id { get; set; }
        public string ActorImg { get; set; }    

        public string ActorName { get; set; }
        public DateTime DateOfBirth { get; set; }   

        public string Description { get; set; }

        public List<Movie> movies { get; set; } =new List<Movie>();

        public List<TvSeries> tvSeries { get; set; } = new List<TvSeries>();    

    }
}
