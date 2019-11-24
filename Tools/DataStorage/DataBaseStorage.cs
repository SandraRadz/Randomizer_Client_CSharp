using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
                cred.Password = EncodePasswordToBase64(password);

                ServiceReference.UserDto findedUser = server.CheckCredentials(cred);

                User user = new User(findedUser.Name, findedUser.Surname, findedUser.Login,  password,
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
                userToSend.Password = EncodePasswordToBase64(user.Password);
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


        public ObservableCollection<Request> GetHistoryByLogin(string login)
        {
            try
            {
                ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                ICollection<RequestDto> requestList = server.GetUserHistoryBy(login);

                ObservableCollection<Request> historyList = new ObservableCollection<Request>();

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
        public static string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
