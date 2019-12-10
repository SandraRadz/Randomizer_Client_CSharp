using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Randomizer_Client.Models;
using Randomizer_Client.Tools;
using Randomizer_Client.Tools.Managers;
using Randomizer_Client.Tools.Navigation;

namespace Randomizer_Client.ViewModels
{
    class SignInViewModel : BaseViewModel
    {

        private string _login;
        private string _password;


        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;


        public SignInViewModel()
        {
            try
            {
                User user = SerializationManager.Deserialize<User>(FileFolderHelper.StorageFilePath);
                _login = user.Login;
                _password = user.Password;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _login = "";
                _password = "";
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value.Replace(" ", "Space");
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> SignInCommand
        {
            get
            {
                 return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                            SignInInplementation, o => CanExecuteCommand()));
            }
        }


        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.SignUp);

                           }));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password);
        }


        private async void SignInInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                User currentUser;
                try
                {
                    currentUser = StationManager.DataStorage.GetUserByLoginAndPassword(_login, _password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка в авторизації користувача {_login}. Спробуйте ще раз");
                    Console.Write(ex.Message);
                    return false;
                }
                if (currentUser == null)
                {
                    MessageBox.Show(
                        $"Помилка в авторизації користувача {_login}. Причина:{Environment.NewLine}Користувач не існує.");
                    return false;
                }
                StationManager.CurrentUser = currentUser;
                SerializationManager.Serialize(currentUser, FileFolderHelper.StorageFilePath);
                MessageBox.Show($"Успішна авторизація для користувача {_login}.");
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.Navigate(ViewType.Randomizer);
            }
        }
    }
}
