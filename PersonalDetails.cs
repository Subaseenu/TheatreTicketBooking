using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreTicketBooking
{
    public enum Gender{male , female , others}
    public class PersonalDetails
    {
        public string Name{get; set;}
        public int Age{get; set;}
        public long PhoneNo{get; set;}
        public Gender Gender{get; set;}
       // public long Phone { get; }
       public PersonalDetails()
       {
        
       }
       

        public PersonalDetails(string name , int age , long mobile , Gender gender)
        {
            Name = name ;
            Age = age;
            PhoneNo = mobile;
            Gender = gender;
        }

       
    }
}