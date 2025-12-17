using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieHub.Models.Actors;
using MovieHub.Models.Countres;
using MovieHub.Models.Directors;
using MovieHub.Models.Genres;
using MovieHub.Models.Languages;
using MovieHub.Models.Librares;
using MovieHub.Models.Movies;
using MovieHub.Models.Reviews;
using MovieHub.Models.Series;
using MovieHub.Models.Users;
using MovieHub.Models.WishLists;

namespace MovieHub.Data
{
    public class DataContext:DbContext
    {


        public DbSet<User> users { get; set; }
        public DbSet<UserDetail> usersDetail { get; set; }  

        public DbSet<WishList> wishLists { get; set; } 

        public DbSet<WishListItems> WishListItems { get; set; }

        public DbSet<Library> libraries { get; set; }   

        public DbSet<LibraryItems> LibraryItems { get; set; }

        public DbSet<Review> reviews { get; set; }

        public DbSet<Director> directors { get; set; }

        public DbSet<Movie> movies { get; set; }

        public DbSet<MovieDetail> movieDetails { get; set; }

        public DbSet<MoviePlayer> moviesPlayer { get; set; }    

        public DbSet<TvSeries> TvSeries { get; set; }   

        public DbSet<SeriesDetail> seriesDetails { get; set; }  

        public DbSet<Season> seasons { get; set; }  

        public DbSet<Episode> episodes { get; set; }

        public DbSet<EpisodePlayer> episodePlayers { get; set; }    

        public DbSet<Actor> actors { get; set; }

        public DbSet<Genre> genres { get; set; }    

        public DbSet<Language> languages { get; set; }

        public DbSet<Country> countries { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieHub;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TvSeries>()
                .HasOne(s => s.SeriesDetail)
                .WithOne(sd => sd.TvSeries)
                .HasForeignKey<SeriesDetail>(sd => sd.SeriesId);
        }


    }
}
