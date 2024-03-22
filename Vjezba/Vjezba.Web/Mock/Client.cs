using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba.Web.Mock
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}
