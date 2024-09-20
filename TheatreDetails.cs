using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreTicketBooking
{
    public class TheatreDetails
    {
        private static int _theatreid=300;
        public string  TheatreID{get; set;}
        public string TheatreName{get; set;}
        public string TheatreLocation{get; set;}
        public TheatreDetails(string theatrename , string theatrelocation)
        {
            _theatreid++;
            TheatreName = theatrename;
            TheatreLocation = theatrelocation;
            TheatreID = "TID"+_theatreid;
        }
         public TheatreDetails(string theatre)
        {
            string[] val = theatre.Split(",");
            _theatreid++;
            TheatreName = val[0];
            TheatreLocation = val[1];
            _theatreid=int.Parse(val[2].Remove(0,3));
            TheatreID = val[2];
        }
        
    }
}