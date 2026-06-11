using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_App
{                                       //S.A
    internal class Admin:User
    {
        public string userName;
        public string password;
        public string role;
        public Admin(string userName, string password) : base(userName, password, "Admin")
        {
        }
    }
}
