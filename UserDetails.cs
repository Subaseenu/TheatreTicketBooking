using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreTicketBooking
{
    public class UserDetails : PersonalDetails, IWallet
    {
        private static int _userid = 1000;
        public string UserId { get;}
        public double WalletBalance { get; set; }

         public UserDetails(string name, int age, long mobile, Gender gender, double amount) : base(name, age, mobile, gender)
        {
            UserId = "UID"+ ++_userid;
            WalletBalance = amount;
        }
        public UserDetails()
        {

        }
         public UserDetails(string val)
        {
            string[] value = val.Split(",");
            WalletBalance = int.Parse(value[0]);
            _userid=int.Parse(value[1].Remove(0,3));
            UserId = value[1];
            Name = value[2];
            Age = int.Parse(value[3]);
            PhoneNo=long.Parse(value[4]);
            Gender = Enum.Parse<Gender>(value[5]);
        }

       
    }
}