using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_App
{
    internal class Customer:User
    {
        public string userName;
        public string password;
        public string role;
        public Customer(string userName, string password) : base(userName, password, "Customer")
        {
        }
    }
}
