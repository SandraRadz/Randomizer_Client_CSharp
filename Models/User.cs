using System;
using System.Collections.Generic;

namespace Randomizer_Client.Models
{
    public class User
    {
        private string _name;
        private string _surname;
        private string _login;
        private string _password;
        private string _email;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public User(string name, string surname, string login, string password, string email)
        {
            _name = name;
            _surname = surname;
            _login = login;
            SetPassword(password);
            _email = email;
        }

        private void SetPassword(string password)
        {
            //TODO Add encription
            _password = password;
        }

    }
}