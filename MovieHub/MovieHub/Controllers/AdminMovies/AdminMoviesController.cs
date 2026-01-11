using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Dtos.AdminMovieDtos;
using MovieHub.FileStreams;
using MovieHub.Models.Movies;
using MovieHub.Requests.AdminMoviesRequests;

namespace MovieHub.Controllers.AdminMovies
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminMoviesController : ControllerBase
    {
        private readonly DataContext _data;

        public AdminMoviesController(DataContext data)
        {
            _data = data;
        }


        [HttpPost("Add-Movies")]
        public async Task<IActionResult> AddMovie([FromForm] CreateMovieRequest req)
        {


            var imgPath = await FileUploader.UploadImg(
           req.CoverImg,
           "uploads/movies"
       );
            Movie movie = new Movie()
            {
               MovieName = req.MovieName,
               CoverImg = imgPath, 
               ReleaseYear = req.ReleaseYear,   
               Rating = req.Rating,
               CreatedAt = DateTime.Now,  
              
            };

            _data.movies.Add(movie);
            await _data.SaveChangesAsync();

            var fullImgUrl = $"{Request.Scheme}://{Request.Host}{imgPath}";

            return Ok(new
            {
               movie.MovieName,
               movie.ReleaseYear,
               movie.Rating,
                ImageUrl = fullImgUrl
            }); 
            

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


        [HttpDelete("Delete-Movie/{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movies = _data.movies.FirstOrDefault(x => x.Id == id);

            _data.movies.Remove(movies);    
            _data.SaveChanges();

            var delmoviesDto = new DeleteMovieDtos
            {
                Id = movies.Id
            };
            return Ok(delmoviesDto);
        }




    }
}
