using Microsoft.AspNetCore.Mvc;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [ApiController]
    [Route("api/v1.0/[Controller]/[Action]")]
    public class AuthController : Controller
    {





        [HttpPost]
        public IActionResult Register(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                return BadRequest("Please provide username !");
            }


            if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Please provide Password !");
            }

            bool isUserExist  = MovieReservation.Models.DataStorage.usersData.Any(x => x.UserName == user.UserName );

            if(isUserExist)
            {

                return BadRequest("User already exists Please login!");
            }


            var maxId = MovieReservation.Models.DataStorage.usersData.Max(x => x.UserId);
            user.UserId = maxId+1;

            MovieReservation.Models.DataStorage.usersData.Add(user);

            return Ok(user);
        }



        [HttpPost]
        public IActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                return BadRequest("Please provide username !");
            }


            if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Please provide Password !");
            }


            var loggedUser= MovieReservation.Models.DataStorage.usersData.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if(loggedUser==null)
            {
               return BadRequest("Invalid credentials !");
            }

            return Ok("Login successfull !");
        }



        [HttpPost]
        public IActionResult ForgetPassword(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                return BadRequest("Please provide username !");
            }


            if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Please provide Password !");
            }


            var existingUser = MovieReservation.Models.DataStorage.usersData.FirstOrDefault(x => x.UserName == user.UserName );
            if (existingUser != null)
            {
                existingUser.Password = user.Password;

            }
            else
            {
                return BadRequest("User not found, please register !");
            }

            return Ok($"Password succesfully changed for user {user.UserName}");

        }



    }
}
