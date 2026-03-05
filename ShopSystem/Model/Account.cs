using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Model
{
    internal class Account
    {
        private string _username;
        private string _password;

        public string Username { get => _username;}
        public string Password { get => _password;}

        public Account(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
