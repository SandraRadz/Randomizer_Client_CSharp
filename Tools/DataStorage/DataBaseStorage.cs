using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Randomizer_Client.Models;

namespace Randomizer_Client.Tools.DataStorage
{
    class DataBaseStorage : IDataStorage
    {
        public bool UserExists(string login)
        {
            // request to server
            if (login == "SandraRadz")
            {
                return true;
            }
            return false;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            // request to server
            return new User("Sasha", "Radz", "SandraRadz", "1234", "o.radz@gmail.com");
        }

        public void AddUser(User user)
        {
            // request to server

        }


    }
}
