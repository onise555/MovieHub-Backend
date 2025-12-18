using MovieHub.Models.Movies;
using MovieHub.Models.Series;

namespace MovieHub.Models.Languages
{
    public class Language
    {
        public int Id { get; set; } 
        public string LanguageName { get; set; }

        public string LanguageImg {  get; set; }   
        
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public List<TvSeries> TvSeries { get; set; } = new List<TvSeries>();    

    }
}
