using MovieHub.Models.Languages;

namespace MovieHub.Models.Series
{
    public class EpisodePlayer
    {
        public int Id { get; set; }
        public string VideoUrl { get; set; }
        public VideoQuality Quality { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }


    }
}
