namespace MovieReservation.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int TheaterId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public int[] SeatNo { get; set; } 

    }
}
