using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Entry
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }

        // default constructor

        public Entry()
        { }

        // greedy constructor

        public Entry(string firstname,
            string lastname,
            string streetaddress1,
            string streetaddress2,
            string city,
            string province,
            string postalcode,
            string emailaddress)
        {
            FirstName = firstname;
            LastName = lastname;
            StreetAddress1 = streetaddress1;
            StreetAddress2 = streetaddress2;
            City = city;
            Province = province;
            PostalCode = postalcode;
            EmailAddress = emailaddress;
        }
    }
}