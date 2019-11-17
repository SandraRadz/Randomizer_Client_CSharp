using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
             //LoaderManeger.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });
            //LoaderManeger.Instance.HideLoader();

            // TO DO: check with db
            MessageBox.Show($"Hello {_login}");
            NavigationManager.Instance.Navigate(ViewType.Randomizer);
        }
    }
}
