using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace TheatreTicketBooking
{
    public class JSONFileManupulation
    {
        public static void Create1()
        {
            if (!Directory.Exists("TheatreTicketBookingjson"))
            {
                Console.WriteLine("Creating Folder..");
                Directory.CreateDirectory("TheatreTicketBookingjson");
            }
            else
            {
                Console.WriteLine("Already Exist..");
            }
            if (!File.Exists("MovieDetails.json"))
            {
                Console.WriteLine("Creating file..");
                File.Create("MovieDetails.json").Close();
            }
            else
            {
                Console.WriteLine("Already Exist..");
            }
            if (!File.Exists("UserDetails.json"))
            {
                Console.WriteLine("Creating file..");
                File.Create("UserDetails.json").Close();
            }
            else
            {
                Console.WriteLine("Already exist");
            }
            if (!File.Exists("BookingStatus.json"))
            {
                Console.WriteLine("Creating file..");
                File.Create("BookingStatus.json").Close();
            }
            else
            {
                Console.WriteLine("Already exist..");
            }
            if (!File.Exists("ScreeningDetails.json"))
            {
                Console.WriteLine("Creating file..");
                File.Create("ScreeningDetails.json").Close();
            }
            else
            {
                Console.WriteLine("Already exist");
            }
            if (!File.Exists("TheatreDetails.json"))
            {
                Console.WriteLine("Creating file..");
                File.Create("TheatreDetails.json").Close();
            }
            else
            {
                Console.WriteLine("Already exist");
            }
        }
        public static void Write1(List<UserDetails> user)
        {
            StreamWriter stream = new StreamWriter("TheatreTicketBookingjson/UserDetails.json");
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsondata = JsonSerializer.Serialize(user, option);
            stream.WriteLine(jsondata);
            stream.Close();
        }
         public static void Writetheatredetails(List<TheatreDetails> theatre)
        {
            StreamWriter stream = new StreamWriter("TheatreTicketBookingjson/TheatreDetails.json");
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsondata = JsonSerializer.Serialize(theatre, option);
            stream.WriteLine(jsondata);
            stream.Close();
        }
         public static void Writemoviedetails(List<MovieDetails> movie)
        {
            StreamWriter stream = new StreamWriter("TheatreTicketBookingjson/MovieDetails.json");
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsondata = JsonSerializer.Serialize(movie, option);
            stream.WriteLine(jsondata);
            stream.Close();
        }
         public static void  Writescreeningdetails(List<ScreeningDetails> screen)
         {
            StreamWriter stream = new StreamWriter("TheatreTicketBookingjson/ScreeningDetails.json");
            var option = new JsonSerializerOptions
            {
                WriteIndented=true
            };
            string value = JsonSerializer.Serialize(screen , option);
            stream.WriteLine(value);
            stream.Close();
         }
         public static void WriteBookingdetails(List<BookingDetails> booking)
         {

               StreamWriter sr = new StreamWriter("TheatreTicketBookingjson/BookingStatus.json");
               var option = new JsonSerializerOptions
               {
                   WriteIndented=true
               };
               string value = JsonSerializer.Serialize( booking , option);
               sr.WriteLine(value);
               sr.Close();
         }
         public static void ReadJson()
         {
            List<UserDetails> user = JsonSerializer.Deserialize<List<UserDetails>>(File.ReadAllText("TheatreTicketBookingjson/UserDetails.json"));
            foreach(UserDetails val in user)
            {
                Console.WriteLine("Name : "+val.Name +"    "+"Age : "+val.Age +"   "+"Gender : "+val.Gender+"   "+"PhoneNo : "+val.PhoneNo+"   "+"UserID : "+val.UserId+"   "+"WalletBalance  :"+val.WalletBalance);
            }
         }
          
    }
}