using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem.Model
{
    //model-klasse die informationen enthält aber keine logische verarbeitung der informationen
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

        //überschreibung der ToString methode um ein für den user lesbaren output zu bekommen
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
