using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Randomizer_Client.Models;
using Randomizer_Client.ServiceReference;

namespace Randomizer_Client.Tools.DataStorage
{
    class DataBaseStorage : IDataStorage
    {


        // TODO correct exception
        public User GetUserByLoginAndPassword(string login, string password)
        {
            try
            {
                ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                ServiceReference.UserCredentialsDto cred = new ServiceReference.UserCredentialsDto();
                cred.Login = login;
                cred.Password = password;

                ServiceReference.UserDto findedUser = server.CheckCredentials(cred);

                User user = new User(findedUser.Name, findedUser.Surname, findedUser.Login, findedUser.Password,
                    findedUser.Email);

                return user;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }


        // TODO correct exception
        public void AddUser(User user)
        {
            try
            {
                ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                ServiceReference.UserDto userToSend = new ServiceReference.UserDto();
                userToSend.Login = user.Login;
                userToSend.Password = user.Password;
                userToSend.Name = user.Name;
                userToSend.Surname = user.Surname;
                userToSend.Email = user.Email;

                server.RegisterUser(userToSend);
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        // TODO correct exception
        public bool UserExists(string login)
        {
            ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                return server.IsUserExist(login);
            
        }

        
        public void SaveHistory(string login, int from, int to, int count)
        {
            try
            {
                ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                ServiceReference.HistoryDto historyToSend = new ServiceReference.HistoryDto();

                historyToSend.Login = login;
                historyToSend.From = from;
                historyToSend.To = to;
                historyToSend.Count = count;

                server.SaveHistory(historyToSend);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }


        public ICollection<Request> GetHistoryByLogin(string login)
        {
            try
            {
                ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                ICollection<RequestDto> requestList = server.GetUserHistoryBy(login);

                ICollection<Request> historyList = new List<Request>();

                foreach (var item in requestList)
                {
                     historyList.Add(new Request(item.From, item.To, item.Count, item.Time));
                }
                
                return historyList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }




    }
}
