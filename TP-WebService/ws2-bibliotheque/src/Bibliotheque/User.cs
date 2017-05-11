using System;
using System.Collections.Generic;
using System.Text;

namespace BibliothequeClass
{
    public class User
    {
        public string Username;
        public string Password;
        public bool Admin;

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
            Admin = false;
        }

        public User(string Username, string Password, bool Admin)
        {
            this.Username = Username;
            this.Password = Password;
            this.Admin = Admin;
        }
    }
}
