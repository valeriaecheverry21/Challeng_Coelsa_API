using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string ProneNumber { get; set; }
    }
}
