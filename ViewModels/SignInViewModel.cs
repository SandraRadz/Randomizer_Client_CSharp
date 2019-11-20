using System;
using System.Collections.Generic;
using System.Linq;
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
                _password = "";
                for (int i = 0; i < value.Length; i++)
                {
                    _password += "*";
                }
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
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                User currentUser;
                try
                {
                    currentUser = StationManager.DataStorage.GetUserByLoginAndPassword(_login, _password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed fo user {_login}. Reason:{Environment.NewLine}{ex.Message}");
                    return false;
                }
                if (currentUser == null)
                {
                    MessageBox.Show(
                        $"Sign In failed fo user {_login}. Reason:{Environment.NewLine}User does not exist.");
                    return false;
                }
                StationManager.CurrentUser = currentUser;
                MessageBox.Show($"Sign In successfull fo user {_login}.");
                return true;
            });
            LoaderManager.Instance.HideLoader();
            
            NavigationManager.Instance.Navigate(ViewType.Randomizer);
        }
    }
}
