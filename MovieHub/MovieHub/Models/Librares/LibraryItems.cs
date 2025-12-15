using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Librares
{
    public class LibraryItems
    {
        public int Id { get; set; } 

        public int LibraryId { get; set; }  

        public Library library { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int SeriesId { get; set; }
        public TvSeries TvSeries { get; set; }

    }
}
