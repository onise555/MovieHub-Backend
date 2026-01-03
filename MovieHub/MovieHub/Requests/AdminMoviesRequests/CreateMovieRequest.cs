namespace MovieHub.Requests.AdminMoviesRequests
{
    public class CreateMovieRequest
    {
        public string MovieName { get; set; }

        public string CoverImg { get; set; }

        public decimal Rating { get; set; }

        public int ReleaseYear { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
