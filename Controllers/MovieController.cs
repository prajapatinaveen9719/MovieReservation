using Microsoft.AspNetCore.Mvc;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [ApiController]
    [Route("api/v1.0/[Controller]")]
    public class MovieController : Controller
    {
         


        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns>return list of movies</returns>
        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(MovieReservation.Models.DataStorage.moviesData);
        }

        /// <summary>
        /// Search a movie by moviename
        /// </summary>
        /// <returns></returns>
        [HttpGet("search/{movieName}")]
        public IActionResult Search([FromRoute] string movieName)
        {
            var searchedMovie = MovieReservation.Models.DataStorage.moviesData.FirstOrDefault(m => m.MovieName.StartsWith(movieName));

            if(searchedMovie!=null)
            {
                return Ok(searchedMovie);

            }

           return Ok("Movie Not Found !");
        }



        /// <summary>
        /// Delete Movie by MovieId
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpDelete("delete/{movieId}")]
        public IActionResult Delete(int movieId)
        {
            var searchedMovie = MovieReservation.Models.DataStorage.moviesData.FirstOrDefault(m => m.MovieId== movieId);

            if (searchedMovie == null)
            {
                return Ok($"Movie Not Found with movie id {movieId}!");
            }

            MovieReservation.Models.DataStorage.moviesData.Remove(searchedMovie);

            return Ok($"Movie with movieid {searchedMovie} deleted successfully ! ");

        }

    }
}
