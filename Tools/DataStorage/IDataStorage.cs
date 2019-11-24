using System.Collections.ObjectModel;
using Randomizer_Client.Models;

namespace Randomizer_Client.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool UserExists(string login);

        User GetUserByLoginAndPassword(string login, string password);

        void AddUser(User user);

        void SaveHistory(string login, int from, int to, int count);

        ObservableCollection<Request> GetHistoryByLogin(string login);

    }
}
