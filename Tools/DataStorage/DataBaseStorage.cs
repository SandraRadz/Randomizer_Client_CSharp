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
                Console.Write(ex);
            }
        }

        // TODO correct exception
        public bool UserExists(string login)
        {
                ServiceReference.Service1Client server = new ServiceReference.Service1Client();

                return server.ExistUser(login);
            
        }

        public void SaveHistory(string login, int from, int to, int count)
        {
            //ServiceReference.Service1Client server = new ServiceReference.Service1Client();

            //ServiceReference.UserDto userToSend = new ServiceReference.UserDto();




        }






    }
}
