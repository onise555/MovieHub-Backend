using MovieHub.Models.Actors;
using MovieHub.Models.Countres;
using MovieHub.Models.Directors;
using MovieHub.Models.Genres;
using MovieHub.Models.Languages;
using MovieHub.Models.Librares;
using MovieHub.Models.Reviews;
using MovieHub.Models.WatchHistores;
using MovieHub.Models.WishLists;

namespace MovieHub.Models.Movies
{
    public class Movie
    {
        public int Id { get; set; } 

        public string MovieName { get; set; }

        public string CoverImg { get; set; }    

        public decimal Rating { get; set; }  

        public int ReleaseYear { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        public MovieDetail MovieDetail { get; set; }    

        public List<WishListItems> WishListItems { get; set; } = new List<WishListItems>();
        public List<LibraryItems> LibraryItems { get; set; } = new List<LibraryItems>();   
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<WatchHistory> WatchHistories { get; set; }= new List<WatchHistory>();

        public List<Director> MovieDirectors { get; set; } = new List<Director>();
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Country> Countries { get; set; } = new List<Country>();
   



    }
}
