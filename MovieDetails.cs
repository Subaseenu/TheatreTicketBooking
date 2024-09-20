using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreTicketBooking
{
    public class MovieDetails
    {
        private static int _movieid = 500;
        public string MovieID { get; set; }
        public string MovieName { get; set; }
        public string Language { get; set; }
        public MovieDetails(string moviename, string language)
        {
            MovieName = moviename;
            Language = language;
            MovieID = "MID" + _movieid++;
        }
        public MovieDetails(string movie)
        {
            string[] val = movie.Split(",");
            MovieName = val[0];
            Language = val[1];
            _movieid = int.Parse(val[2].Remove(0, 3));
            MovieID = val[2];
        }
    }
}