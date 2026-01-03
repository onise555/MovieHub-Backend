using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Dtos.AdminMovieDtos;
using MovieHub.Models.Movies;
using MovieHub.Requests.AdminMoviesRequests;

namespace MovieHub.Controllers.AdminMovies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminMoviesController : ControllerBase
    {
        private readonly DataContext _data;

        public AdminMoviesController(DataContext data)
        {
            _data = data;
        }


        [HttpPost("Add-Movies")]
        public ActionResult AddMovie(CreateMovieRequest req)
        {
            Movie movie = new Movie()
            {
               MovieName = req.MovieName,
               CoverImg = req.CoverImg, 
               ReleaseYear = req.ReleaseYear,   
               Rating = req.Rating,
               CreatedAt = req.CreatedAt,
               UpdatedAt = req.UpdatedAt,   
              
            };

            _data.movies.Add(movie);
            _data.SaveChanges();

            return Ok(movie);   
        }


        [HttpGet("Movies")]
        public ActionResult GetMovies()
        {

            var moivies = _data.movies.Select(x=> new MoviesDtos
            {
                Id = x.Id,
                MovieName = x.MovieName,
                CoverImg = x.CoverImg,
                ReleaseYear = x.ReleaseYear,
                Rating = x.Rating,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToList();

            return Ok(moivies); 
        }
    }
}
