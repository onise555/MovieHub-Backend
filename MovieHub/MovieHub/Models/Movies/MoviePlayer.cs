using MovieHub.Models.Languages;

namespace MovieHub.Models.Movies
{
    public class MoviePlayer
    {

        public int Id { get; set; }
        public string VideoUrl { get; set; }
        public VideoQuality Quality { get; set; }

        public int MovieDetailId { get; set; }
        public  MovieDetail MovieDetail { get; set; }

        public int LanguageId { get; set; }
        public  Language Language { get; set; }





    }
}
