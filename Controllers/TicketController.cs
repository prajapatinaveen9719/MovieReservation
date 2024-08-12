using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [ApiController]
    [Route("api/v1.0/[Controller]/[Action]")]
    public class TicketController : Controller
    {
        /// <summary>
        /// Book ticket for a movie
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BookTicket(Ticket ticket)
        {
            if (ticket.MovieId==0)
            {
                return BadRequest("Please provide movieId");
            }

            if (ticket.UserId==0)
            {
                return BadRequest("Please provide userid");
            }

            if (ticket.TheaterId == 0)
            {
                return BadRequest("Please provide TheaterId");
            }

            Int32 maxId = Convert.ToInt32(MovieReservation.Models.DataStorage.ticketsData.Max(x=>x.TicketId));

            ticket.TicketId = maxId + 1;
            

            MovieReservation.Models.DataStorage.ticketsData.Add(ticket);

            return Ok(new  { StatusCode = 200, Message = "Ticket booked successfully",ticketInfo=ticket });

        }

        /// <summary>
        /// Update No of available seats 
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult UpdateTicket(Theater theater)
        {
            if (theater.TheaterId==0)
            {
                return BadRequest("Please provide TheaterId");
            }

            if (theater.MovieId == 0)
            {
                return BadRequest("Please provide MovieId");
            }


            if (theater.TotalSeat == 0)
            {
                return BadRequest("Please provide TotalSeat");
            }

            var theaterInfo = MovieReservation.Models.DataStorage.theaterData.FirstOrDefault(x => x.TheaterId == theater.TheaterId && x.MovieId==theater.MovieId );

            if(theaterInfo==null)
            {
                return BadRequest("Theater info not available !");
            }

            theaterInfo.TotalSeat = theater.TotalSeat;

            return Ok(new { StatusCode = 200, Message = "Seats updated successfully", Data = theaterInfo });
        }


    }
}
