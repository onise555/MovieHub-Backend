using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Librares
{
    public class LibraryItems
    {
        public int Id { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        public int LibraryId { get; set; }  

        public Library Library { get; set; }

        public int? MovieId { get; set; }

        public Movie? Movie { get; set; }

        public int? SeriesId { get; set; }
        public TvSeries? TvSeries { get; set; }

    }
}
