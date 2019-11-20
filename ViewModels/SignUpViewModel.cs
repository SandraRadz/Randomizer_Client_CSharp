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
    class SignUpViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _login;
        private string _password;
        private string _passwordConfirmation;


        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
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
                _password = "";
                for (int i = 0; i < value.Length; i++)
                {
                    _password += "*";
                }
                OnPropertyChanged();
            }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set
            {
                _passwordConfirmation = "";
                for (int i = 0; i < value.Length; i++)
                {
                    _passwordConfirmation += "*";
                }
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> SignInCommand
        {
            get { 
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.SignIn);
                           }));
            }
        }

        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (
                           _signUpCommand = new RelayCommand<object>(SignUpInplementation, o => CanExecuteCommand()));
            }
        }


        // TO DO: check  _password == _passwordConfirmation
        // TO DO: print error
        // TO DO: validation for fields
        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) &&
                   !string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_login) &&
                   !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_passwordConfirmation) &&
                    _password == _passwordConfirmation;
        }

        private async void SignUpInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                // TO DO: send to DB
                Thread.Sleep(2000);
            });
            LoaderManager.Instance.HideLoader();
            
            MessageBox.Show($"User with name {_login} was created");
            NavigationManager.Instance.Navigate(ViewType.Randomizer);
        }

    }
}
