using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.WishLists
{
    public class WishListItems
    {
        public int Id { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public int WishListId { get; set; }
        public WishList WishList { get; set; }

        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int? SeriesId { get; set; }
        public TvSeries? TvSeries { get; set; }




    }
}
