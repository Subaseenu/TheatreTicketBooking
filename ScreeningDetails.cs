using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreTicketBooking
{
    public class ScreeningDetails
    {
        public string MovieID { get; set; }
        public string TheatreID { get; set; }
        public int NoOfSeatsAvailable { get; set; }
        public int TicketPrice { get; set; }
        public ScreeningDetails(string movieid, string theatreid,  int ticketprice , int seatavailable)
        {
            MovieID = movieid;
            TheatreID = theatreid;
            TicketPrice = ticketprice;
            NoOfSeatsAvailable = seatavailable;
        }
         public ScreeningDetails(string screen)
        {
            string[] val = screen.Split(",");
            MovieID = val[0];
            TheatreID = val[1];
            TicketPrice = int.Parse(val[2]);
            NoOfSeatsAvailable = int.Parse(val[3]);
        }
    }
}