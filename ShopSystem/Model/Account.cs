using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Model
{
    internal class Account
    {
        private string _username;
        private string _password;
        private bool _isAdmin;

        public string Username { get => _username; }
        public string Password { get => _password; }
        public bool IsAdmin { get => _isAdmin; }

        public Account(string username, string password, bool isAdmin)
        {
            _username = username;
            _password = password;
            _isAdmin = isAdmin;
        }

        public override string ToString()
        {
            return $"{_username} | {_password} | {_isAdmin}";
        }

        //public string Username()
        //{ return _username; }
        //public string Password() 
        //{ return _password; }
    }
}
