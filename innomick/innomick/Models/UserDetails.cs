using System;
using System.Collections.Generic;
using System.Text;

namespace innomick.Models
{
    public class UserDetails
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
    }
}
