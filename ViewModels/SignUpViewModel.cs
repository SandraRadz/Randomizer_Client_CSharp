﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Randomizer_Client.Models;
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

        public SignUpViewModel()
        {
            
        }
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
                _password = value;
                OnPropertyChanged();
            }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set
            {
                _passwordConfirmation = value;
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


        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) &&
                   !string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_login) &&
                   !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_passwordConfirmation);
        }

       
        private async void SignUpInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);

                    if (!new EmailAddressAttribute().IsValid(_email))
                    {
                        MessageBox.Show($"Помилка в реєстрації користувача {_login}. Reason:{Environment.NewLine} Email {_email} не коректний.");
                        return false;
                    }
                    if (_password != _passwordConfirmation)
                    {
                        MessageBox.Show($"Помилка в реєстрації користувача {_login}. Reason:{Environment.NewLine}Пароль і підтвердження паролю не збігаються");
                        return false;
                    }
                    if (StationManager.DataStorage.UserExists(_login))
                    {
                        MessageBox.Show($"Помилка в реєстрації користувача {_login}. Причина:{Environment.NewLine} Користувач з таким логіном вже існує. Оберіть інший");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка в реєстрації користувача {_login}. Спробуйте ще раз.");
                    Console.Write(ex.Message);
                    return false;
                }
                try
                {
                    var user = new User(_firstName, _lastName, _login, _password, _email);
                    StationManager.DataStorage.AddUser(user);
                    StationManager.CurrentUser = user;

                    SerializationManager.Serialize(user, FileFolderHelper.StorageFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка в реєстрації користувача {_login}. Спробуйте ще раз.");
                    Console.Write(ex.Message);
                    return false;
                }
                MessageBox.Show($"Користувач {_login}був успішно створений.");
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
