using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreTicketBooking
{
    public enum BookingStatus { Booked, Cancelled }
    public class BookingDetails
    {
        private static int _bookingid = 7000;
        public string BookingID { get; set; }
        public string UserID { get; set; }
        public string MovieID { get; set; }
        public string TheatreID { get; set; }
        public int SeatCount { get; set; }
        public double TotalAmount { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public BookingDetails(string userid, string movieid, string theatreid, int seatcount, double amount, BookingStatus bookingStatus)
        {
            _bookingid++;
            BookingID = "BID" + _bookingid;
            UserID = userid;
            MovieID = movieid;
            TheatreID = theatreid;
            SeatCount = seatcount;
            TotalAmount = amount;
            BookingStatus = bookingStatus;

        }
        public BookingDetails(string user)
        {
            string[] val = user.Split(",");
            _bookingid = int.Parse(val[0].Remove(0, 3));
            BookingID = val[0];
            UserID = val[1];
            MovieID = val[2];
            TheatreID = val[3];
            SeatCount = int.Parse(val[4]);
            TotalAmount = int.Parse(val[5]);
            BookingStatus = Enum.Parse<BookingStatus>(val[6]);

        }

    }
}