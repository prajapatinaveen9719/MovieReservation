namespace MovieReservation.Models
{
    public static class DataStorage
    {

        public static List<Movie> moviesData = new List<Movie> {
              new Movie { MovieId=1, MovieName="Iron Man", Description="Iron Man" },
              new Movie { MovieId=2, MovieName="Spider Man", Description="Spider Man" }
            };



        public static List<User> usersData = new List<User>
       {
           new User{ UserId=1,UserName="admin",Password="admin@123" }
       };

        public static List<Ticket> ticketsData { get; } = new List<Ticket>
    {
        new Ticket { TicketId = 1, MovieId = 1, UserId = 1,SeatNo=[1,2] },
        new Ticket { TicketId = 2, MovieId = 1, UserId = 1,SeatNo=[3,4] }

    };


        public static List<Theater> theaterData { get; } = new List<Theater>
    {
        new Theater { TheaterId = 1, MovieId = 1, TotalSeat = 30 },
        new Theater { TheaterId = 2, MovieId = 2, TotalSeat = 50 }

    };

    }
}
