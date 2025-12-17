using MovieHub.Models.Actors;
using MovieHub.Models.Countres;
using MovieHub.Models.Directors;
using MovieHub.Models.Genres;
using MovieHub.Models.Languages;
using MovieHub.Models.Librares;
using MovieHub.Models.Reviews;
using MovieHub.Models.WishLists;

namespace MovieHub.Models.Series
{
    public class TvSeries
    {
        public int Id { get; set; } 

        public string SerieName { get; set; }   

        public string CoverImg { get; set; }        

        public double Rating { get; set; }      

        public int ReleasYear { get; set; }

        public SeriesDetail SeriesDetail { get; set; }

        public List<Director> SerieDirectors { get; set; } = new List<Director>();

        public List<Season> seasons { get; set; }= new List<Season>();  
        public List<WishListItems> WishListItems { get; set; } = new List<WishListItems>();

        public List<LibraryItems> LibraryItems { get; set; } = new List<LibraryItems>();

        public List<Review> Reviews { get; set; } = new List<Review>();


        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<Genre> genres { get; set; } = new List<Genre>();

        public List<Language> languages { get; set; } = new List<Language>();

        public List<Country> countries { get; set; } = new List<Country>();
    }
}
