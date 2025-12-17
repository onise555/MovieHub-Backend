using MovieHub.Models.Movies;
using MovieHub.Models.Series;
using MovieHub.Models.Users;

namespace MovieHub.Models.Reviews
{
    public class Review
    {

        public int Id { get; set; }

        public string Title { get; set; }   
        public string Comment { get; set; }
         
        public double Rating { get; set; }
        
        public DateTime CreateAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? MovieId { get; set; }    

        public Movie Movie { get; set; }

        public int? SeriesId { get; set; }
        public TvSeries TvSeries { get; set; }
    }
}
