using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class User
    {
        public required int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public UserType UserType { get; set; }
        public DateTime RegistrationDate { get; set; }


        public User ()
        {
            RegistrationDate = DateTime.Now;
        }

    }
}
