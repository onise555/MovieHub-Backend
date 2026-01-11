namespace MovieHub.Requests.AdminMoviesRequests
{
    public class CreateMovieRequest
    {
        public string MovieName { get; set; }

        public IFormFile CoverImg { get; set; }

        public decimal Rating { get; set; }

        public int ReleaseYear { get; set; }
    }
}
