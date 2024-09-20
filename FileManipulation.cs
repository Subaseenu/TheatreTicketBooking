using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace TheatreTicketBooking
{
    public class FileManipulation
    {
        public static void Create()
        {
            if (!Directory.Exists("TheatreTicketBooking"))
            {
                Console.WriteLine("Creating Folder..");
                Directory.CreateDirectory("TheatreTicketBooking");
            }
            else
            {
                Console.WriteLine("Already Exist..");
            }
            if (!File.Exists("MovieDetails.csv"))
            {
                Console.WriteLine("Creating file..");
                File.Create("MovieDetails.csv").Close();
            }
            else
            {
                Console.WriteLine("Already Exist..");
            }
            if (!File.Exists("UserDetails.csv"))
            {
                Console.WriteLine("Creating file..");
                File.Create("UserDetails.csv").Close();
            }
            else
            {
                Console.WriteLine("Already exist");
            }
            if (!File.Exists("BookingStatus.csv"))
            {
                Console.WriteLine("Creating file..");
                File.Create("BookingStatus.csv").Close();
            }
            else
            {
                Console.WriteLine("Already exist..");
            }
            if (!File.Exists("ScreeningDetails.csv"))
            {
                Console.WriteLine("Creating file..");
                File.Create("ScreeningDetails.csv").Close();
            }
            else
            {
                Console.WriteLine("Already exist");
            }
            if (!File.Exists("TheatreDetails.csv"))
            {
                Console.WriteLine("Creating file..");
                File.Create("TheatreDetails.csv").Close();
            }
            else
            {
                Console.WriteLine("Already exist");
            }
        }
        public static void WriteCSV()
        {

            string[] arr1 = new string[Program.bookingDetailsList.Count];
            for (int i = 0; i < Program.bookingDetailsList.Count; i++)
            {
                arr1[i] = Program.bookingDetailsList[i].BookingID + "," + Program.bookingDetailsList[i].UserID + "," + Program.bookingDetailsList[i].MovieID + "," + Program.bookingDetailsList[i].TheatreID + "," + Program.bookingDetailsList[i].SeatCount + "," + Program.bookingDetailsList[i].TotalAmount+","+Program.bookingDetailsList[i].BookingStatus;
            }
            
            File.WriteAllLines("BookingStatus.csv", arr1);

            string[] arr2 = new string[Program.movieDetailsList.Count];
            for (int i = 0; i < Program.movieDetailsList.Count; i++)
            {
                arr2[i] = Program.movieDetailsList[i].MovieName + "," + Program.movieDetailsList[i].Language + "," + Program.movieDetailsList[i].MovieID;
            }
            File.WriteAllLines("MovieDetails.csv", arr2);

            string[] arr3 = new string[Program.screeningDetailsList.Count];
            for (int i = 0; i < Program.screeningDetailsList.Count; i++)
            {
                
                arr3[i] = Program.screeningDetailsList[i].MovieID + "," + Program.screeningDetailsList[i].TheatreID + "," + Program.screeningDetailsList[i].TicketPrice + "," + Program.screeningDetailsList[i].NoOfSeatsAvailable;
            }
            File.WriteAllLines("ScreeningDetails.csv", arr3);

            string[] arr4 = new string[Program.theatreDetailslist.Count];
            for (int i = 0; i < Program.theatreDetailslist.Count; i++)
            {
                arr4[i] = Program.theatreDetailslist[i].TheatreName + "," + Program.theatreDetailslist[i].TheatreLocation + "," + Program.theatreDetailslist[i].TheatreID;
            }
            File.WriteAllLines("TheatreDetails.csv", arr4);


            string[] arr5 = new string[Program.userdetails.Count];
            for (int i = 0; i < Program.userdetails.Count; i++)
            {
                arr5[i] = Program.userdetails[i].WalletBalance + "," + Program.userdetails[i].UserId + "," + Program.userdetails[i].Name + "," + Program.userdetails[i].Age + "," + Program.userdetails[i].PhoneNo + "," + Program.userdetails[i].Gender;
            }
            File.WriteAllLines("UserDetails.csv", arr5);
        }
        public static void ReadCSV()
        {
            string[] val1 = File.ReadAllLines("BookingStatus.csv");
            foreach (string n in val1)
            {
                BookingDetails booking = new BookingDetails(n);
                Program.bookingDetailsList.Add(booking);
            }

            string[] val2 = File.ReadAllLines("MovieDetails.csv");
            foreach (string m in val2)
            {
                MovieDetails movie = new MovieDetails(m);
                Program.movieDetailsList.Add(movie);
            }

            string[] val3 = File.ReadAllLines("ScreeningDetails.csv");
            foreach (string n in val3)
            {
                ScreeningDetails screening = new ScreeningDetails(n);
                Program.screeningDetailsList.Add(screening);
            }

            string[] val4 = File.ReadAllLines("TheatreDetails.csv");
            foreach (string n in val4)
            {
                TheatreDetails theatre = new TheatreDetails(n);
                Program.theatreDetailslist.Add(theatre);
            }
            string[] val5 = File.ReadAllLines("UserDetails.csv");
            foreach (string n in val5)
            {
                UserDetails user = new UserDetails(n);
                Program.userdetails.Add(user);
            }
        }
    }
}