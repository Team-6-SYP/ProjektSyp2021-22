using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entwurf
{
    public abstract class Person : Rowversion
    {
        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string Adress { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public DateTime DayOfBirth { get; set; }



        public string Fullname => $"{Firstname} {Lastname}";

        public int Age; //gehört berechnet

    }
}