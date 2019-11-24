using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer_Client.Models;
using Randomizer_Client.ServiceReference;

namespace Randomizer_Client.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool UserExists(string login);

        User GetUserByLoginAndPassword(string login, string password);

        void AddUser(User user);

        void SaveHistory(string login, int from, int to, int count);

        ICollection<Request> GetHistoryByLogin(string login);

    }
}
