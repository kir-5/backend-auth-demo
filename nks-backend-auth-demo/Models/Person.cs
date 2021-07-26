using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nks_backend_auth_demo.Models
{
    public class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}