using MovieHub.Models.Languages;

namespace MovieHub.Models.Series
{
    public class EpisodePlayer
    {
        public int Id { get; set; } 

        public string Video {  get; set; }

        public string Quality { get; set; }

        public int EpisodeId { get; set; }  

        public Episode episode { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }


    }
}
