namespace MovieHub.Models.Movies
{
    public class MovieDetail
    {

        public int Id { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }   

        public int  MovieId {  get; set; }  
        public Movie Movie { get; set; }


        public List<MoviePlayer> MoviePlayers { get; set; } = new List<MoviePlayer>();





    }
}
