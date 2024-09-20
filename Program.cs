using System;
using System.Collections.Generic;
using System.IO;
namespace TheatreTicketBooking;
class Program
{
    // public static List<PersonalDetails> personaldetails = new List<PersonalDetails>();
    public static List<UserDetails> userdetails = new List<UserDetails>();
    public static List<TheatreDetails> theatreDetailslist = new List<TheatreDetails>();
    public static List<ScreeningDetails> screeningDetailsList = new List<ScreeningDetails>();
    public static List<MovieDetails> movieDetailsList = new List<MovieDetails>();
    public static List<BookingDetails> bookingDetailsList = new List<BookingDetails>();
    public static UserDetails currentuser;
    public static string Userid;
    public static ScreeningDetails screeningDetails;
    public static BookingDetails booking;
    public static string theatreid;
    public static string movieid;
    public static void Main(string[] args)
    {

        FileManipulation.Create();
        JSONFileManupulation.Create1();
        if (File.ReadAllLines("BookingStatus.csv").Length == 0 && File.ReadAllLines("MovieDetails.csv").Length == 0 && File.ReadAllLines("ScreeningDetails.csv").Length == 0 && File.ReadAllLines("TheatreDetails.csv").Length == 0 && File.ReadAllLines("UserDetails.csv").Length == 0)
        {

            DefaultTicketBookingData();
        }
        FileManipulation.ReadCSV();
       // JSONFileManupulation.ReadJson();

        Console.WriteLine("--------WELCOME TO THE ONLINE THEATRE TICKET BOOKING-------");
        string val = "yes";
        do
        {
            Console.WriteLine("..Main Menu..");
            Console.WriteLine("Select The Below Option");
            Console.WriteLine("1 . User Registration");
            Console.WriteLine("2 . Login");
            Console.WriteLine("3 . Exit");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    {
                        UserRegistration();

                        break;
                    }
                case "2":
                    {
                        LoginAndPurchase();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Thank You!!");
                        val = "no";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option Please Try Again");
                        break;
                    }
            }
        } while (val == "yes");
        FileManipulation.WriteCSV();
        JSONFileManupulation.Write1(userdetails);
        JSONFileManupulation.WriteBookingdetails(bookingDetailsList);
        JSONFileManupulation.Writemoviedetails(movieDetailsList);
        JSONFileManupulation.Writescreeningdetails(screeningDetailsList);
        JSONFileManupulation.Writetheatredetails(theatreDetailslist);

    }
    public static void DefaultTicketBookingData()
    {
        // Theatre Details default values..

        theatreDetailslist.Add(new TheatreDetails("Inox", "Anna Nagar"));
        theatreDetailslist.Add(new TheatreDetails("Ega Theatre", "Chetpet"));
        theatreDetailslist.Add(new TheatreDetails("Kamala", "Vadapalani"));

        // Movide details default values..
        movieDetailsList.Add(new MovieDetails("Bagubali", "Telungu"));
        movieDetailsList.Add(new MovieDetails("Ponniyin Selval", "Tamil"));
        movieDetailsList.Add(new MovieDetails("Cobra", "Tamil"));
        movieDetailsList.Add(new MovieDetails("Vikram", "Hindi(Dubbed)"));
        movieDetailsList.Add(new MovieDetails("Vikram", "Tamil"));
        movieDetailsList.Add(new MovieDetails("Beast", "English"));

        // Screening Details default values..

        screeningDetailsList.Add(new ScreeningDetails("MID501", "TID301", 200, 5));
        screeningDetailsList.Add(new ScreeningDetails("MID502", "TID301", 300, 2));
        screeningDetailsList.Add(new ScreeningDetails("MID506", "TID301", 50, 1));
        screeningDetailsList.Add(new ScreeningDetails("MID501", "TID302", 400, 11));
        screeningDetailsList.Add(new ScreeningDetails("MID505", "TID302", 300, 20));
        screeningDetailsList.Add(new ScreeningDetails("MID504", "TID302", 500, 2));
        screeningDetailsList.Add(new ScreeningDetails("MID505", "TID303", 100, 11));
        screeningDetailsList.Add(new ScreeningDetails("MID502", "TID303", 200, 20));
        screeningDetailsList.Add(new ScreeningDetails("MID504", "TID303", 350, 2));

        // User Details default values...

        userdetails.Add(new UserDetails("Ravichandran", 30, 9876545678, Gender.male, 1000));
        userdetails.Add(new UserDetails("Baskaran", 30, 5467890345, Gender.male, 1000));


        // Booking Details default valuess..

        bookingDetailsList.Add(new BookingDetails("UID1001", "MID501", "TID301", 1, 236, BookingStatus.Booked));
        bookingDetailsList.Add(new BookingDetails("UID1001", "MID504", "TID302", 1, 472, BookingStatus.Booked));
        bookingDetailsList.Add(new BookingDetails("UID1002", "MID505", "TID302", 1, 354, BookingStatus.Booked));

    }
    public static void UserRegistration()
    {
        Console.WriteLine("User Registration Will Be Selected!");
        string name = "";
        bool check = false;
        do
        {
            Console.WriteLine("Enter Your Name");
            name = Console.ReadLine();
            if (name.Contains("  ") || string.IsNullOrEmpty(name) || SpecialCase(name))
            {
                check = false;
                Console.WriteLine("Please Enter Valid Name");
            }
            else
            {
                check = true;
                break;
            }

        } while (!check);

        int Age;
        do
        {
            Console.WriteLine("Enter Your Age (Between 10 and 99)");
            string age = Console.ReadLine().Trim();
            if (int.TryParse(age, out Age) && age.Length == 2)
            {
                if (Age > 0 && Age <= 99)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not Allowed The Age Is  Above 99");
                }
            }
            else
            {
                Console.WriteLine("Wrong Input Please Try Again");
            }

        } while (true);
        Gender gender1;
        do
        {
            Console.WriteLine("Enter Your Gender (male / female / others)");
            string gender = Console.ReadLine().Trim();
            if (Enum.TryParse(gender, true, out gender1))
            {
                if (int.TryParse(gender, out _))
                {
                    Console.WriteLine("Gender is not a digits");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input Please Try Again");
            }
        } while (true);

        long phone1;
        do
        {
            Console.WriteLine("Enter Your Phone Number");
            string phone = Console.ReadLine().Trim();
            if (long.TryParse(phone, out phone1) && phone.Length == 10)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input Please Try Again");
            }

        } while (true);

        double amount1;
        do
        {
            Console.WriteLine("Enter Your Wallet Balance");
            string amount = Console.ReadLine();
            if (double.TryParse(amount, out amount1))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input Please Try Again");
            }

        } while (true);

        UserDetails userDetails = new UserDetails(name, Age, phone1, gender1, amount1);
        userdetails.Add(userDetails);

        Console.WriteLine("Registration was Successful!!!...");
        Console.WriteLine("Your UserID Is : " + userDetails.UserId);

    }
    public static void LoginAndPurchase()
    {

        bool check = false;
        Console.WriteLine("Enter Your UserID");
        string userid = Console.ReadLine().ToUpper();
        Userid = userid;
        foreach (var n in userdetails)
        {
            if (Userid == n.UserId)
            {
                check = true;
                currentuser = n;
                Submenu();
            }
        }
        if (!check)
        {
            Console.WriteLine("Invalid Registration Number");
        }
    }
    public static void Submenu()
    {
        Console.WriteLine("----SUB MENU-----");
        string val = "yes";
        do
        {
            Console.WriteLine("1 . Ticket Booking");
            Console.WriteLine("2 . Ticket Cancellation");
            Console.WriteLine("3 . Booking History");
            Console.WriteLine("4 . Wallet Recharge");
            Console.WriteLine("5 . Show Wallet Balance");
            Console.WriteLine("6 . Exit");
            Console.WriteLine("Select the option");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        TicketBooking();
                        Console.WriteLine();
                        break;
                    }
                case 2:
                    {
                        TicketCancellation();
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    {
                        BookingHistory();
                        Console.WriteLine();
                        break;
                    }
                case 4:
                    {
                        ReachargeWalletBalance();
                        Console.WriteLine();
                        break;
                    }
                case 5:
                    {
                        WalletBalance();
                        Console.WriteLine();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Thank You !");
                        val = "no";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option Please Try Again");
                        break;
                    }
            }
        } while (val == "yes");

    }
    public static void TicketBooking()
    {
        foreach (var n in theatreDetailslist)
        {
            Console.WriteLine("TheatreID       : " + n.TheatreID);
            Console.WriteLine("TheatreName     : " + n.TheatreName);
            Console.WriteLine("TheatreLocation : " + n.TheatreLocation);
            Console.WriteLine("-----------------");

        }
        Console.WriteLine("Select The TheatreID");
        theatreid = Console.ReadLine().ToUpper();
        List<string> movieID = new List<string>();
        foreach (var m in screeningDetailsList)
        {
            if (theatreid == m.TheatreID)
            {
                Console.WriteLine("MovieID           : " + m.MovieID);
                Console.WriteLine("TheatreID         : " + m.TheatreID);
                Console.WriteLine("Ticket Price      : " + m.TicketPrice);
                Console.WriteLine("SeatAvailability  : " + m.NoOfSeatsAvailable);
                movieID.Add(m.MovieID);
                Console.WriteLine("---------------------------------------------");
            }
        }


        Console.WriteLine("Select The MovieID");
        movieid = Console.ReadLine().ToUpper();
        bool check = false;
        foreach (string m in movieID)
        {
            if (movieid == m)
            {
                check = true;
                break;
            }
        }
        if (check)
        {
            int ticket1;
            do
            {
                Console.WriteLine("How Much Ticket You Want");
                string ticket = Console.ReadLine();
                if (int.TryParse(ticket, out ticket1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input Please Enter The Number Format");
                }

            } while (true);

            int count = 0;
            int ticketprice = 0;
            foreach (var n in screeningDetailsList)
            {
                foreach (var m in movieID)
                {
                    if (movieid == n.MovieID && movieid == m)
                    {
                        screeningDetails = n;
                        count = n.NoOfSeatsAvailable;
                        ticketprice = n.TicketPrice;
                        break;
                    }
                }

            }
            if (count >= ticket1)
            {
                double tot = (ticket1 * ticketprice) + (ticket1 * ticketprice * 0.18);
                if (currentuser.WalletBalance >= tot)
                {
                    BookingDetails booked1 = new BookingDetails(Userid, movieid, theatreid, ticket1, tot, BookingStatus.Booked);
                    bookingDetailsList.Add(booked1);
                    currentuser.WalletBalance -= tot;
                    screeningDetails.NoOfSeatsAvailable -= ticket1;
                    Console.WriteLine("Ticket Booking Successful...!!!!");
                    Console.WriteLine("BookingID : " + booked1.BookingID);
                }
                else
                {
                    Console.WriteLine("Insufficient Balance Please Recharge Now");
                }
            }
            else
            {
                Console.WriteLine("Required Count Is Not Available . Available Count : " + count);
            }
        }
        else
        {
            Console.WriteLine("Invalid MovideID Please Enter The Valid MovieID.");
        }

    }

    public static void TicketCancellation()
    {
        bool check = false;
        foreach (var n in bookingDetailsList)
        {
            if (Userid == n.UserID && n.BookingStatus == BookingStatus.Booked)
            {
                check = true;
                Console.WriteLine("BookingID    : " + n.BookingID);
                Console.WriteLine("MovieID      : " + n.MovieID);
                Console.WriteLine("n.TheatreID  : " + n.TheatreID);
                Console.WriteLine("UserID       : " + n.UserID);
                Console.WriteLine("SeatCount    :" + n.SeatCount);
                Console.WriteLine("TotalAmount  :" + n.TotalAmount);
                Console.WriteLine("BookingStatus:" + n.BookingStatus);
            }
        }
        if (check)
        {
            Console.WriteLine("Enter Your BookingID For the Cancellation");
            string bookingid = Console.ReadLine().ToUpper();
            int bookedseat = 0;
            double totamount = 0;
            foreach (var n in bookingDetailsList)
            {

                if (bookingid == n.BookingID && n.BookingStatus == BookingStatus.Booked)
                {
                    bookedseat = n.SeatCount;
                    totamount = n.TotalAmount;
                    n.BookingStatus = BookingStatus.Cancelled;
                    Console.WriteLine("Cancelled Successful......");
                    break;
                }
            }
            foreach (var n in screeningDetailsList)
            {
                if (n.MovieID == movieid && n.TheatreID == theatreid)
                {
                    n.NoOfSeatsAvailable += bookedseat;
                    currentuser.WalletBalance += totamount - 20;
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Your Not Booking The Ticket Please Booking Now..");
        }
    }

    public static void BookingHistory()
    {
        bool check = false;
        foreach (var n in bookingDetailsList)
        {
            if (n.UserID == Userid)
            {
                check = true;
                Console.WriteLine("BookingID     : " + n.BookingID);
                Console.WriteLine("MovieID       : " + n.MovieID);
                Console.WriteLine("UserID        : " + n.UserID);
                Console.WriteLine("TheatreID     : " + n.TheatreID);
                Console.WriteLine("SeatCount     : " + n.SeatCount);
                Console.WriteLine("TotalAmount   : " + n.TotalAmount);
                Console.WriteLine("BookingStatus : " + n.BookingStatus);
                Console.WriteLine(".................");
            }
        }
        if (!check)
        {
            Console.WriteLine("Your Not Booking The Ticket Please Booking Now..");
        }
    }
    public static void ReachargeWalletBalance()
    {
        int Amount;
        do
        {
            Console.WriteLine("Enter The Amount For The Wallet Recharge");
            string amount = Console.ReadLine();
            if (int.TryParse(amount, out Amount))
            {
                if (Amount > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter The valid amount");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input Please Try Again");
            }
        } while (true);
        currentuser.WalletBalance += Amount;
        Console.WriteLine("Wallet Recharge Successful..!!!!");
    }
    public static void WalletBalance()
    {
        Console.WriteLine("YOUR WALLET BALANCE IS : " + currentuser.WalletBalance);
    }
    public static bool SpecialCase(string name)
    {
        foreach (char v in name)
        {
            if (!char.IsLetter(v) && !char.IsWhiteSpace(v))
            {
                return true;
            }
        }
        return false;
    }
}