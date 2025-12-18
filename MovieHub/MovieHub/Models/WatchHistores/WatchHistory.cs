using MovieHub.Models.Movies;
using MovieHub.Models.Series;
using MovieHub.Models.Users;

namespace MovieHub.Models.WatchHistores
{
    public class WatchHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }

        public int WatchedSeconds { get; set; }
        public int TotalSeconds { get; set; }

        public DateTime LastWatchedAt { get; set; } = DateTime.UtcNow;

    }
}
