using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer_Client.Models;

namespace Randomizer_Client.Tools.DataStorage
{
    class DataBaseStorage : IDataStorage
    {
        public bool UserExists(string login)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }


    }
}
