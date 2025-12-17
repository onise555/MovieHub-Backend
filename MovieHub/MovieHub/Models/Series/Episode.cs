using MovieHub.Models.WatchHistores;

namespace MovieHub.Models.Series
{
    public class Episode
    {
        public int Id { get; set; } 

        public string EpisodeName { get; set; } 

        public int EpisodeNumber { get; set; }

        public int Duration { get; set; }

        public int SeasonId { get; set; }   

        public Season Season { get; set; }  

        public List<EpisodePlayer> Player { get; set; } = new List<EpisodePlayer>();

        public List<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();

    }
}
