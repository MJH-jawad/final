using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_App
{
    internal class User
    {
        public string UserName;
        public string Password;
        public string Role;

        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
