using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer_Client.Tools;
using Randomizer_Client.Tools.Managers;
using Randomizer_Client.Tools.Navigation;

namespace Randomizer_Client.ViewModels
{
    class SignInViewModel : BaseViewModel
    {

        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;

        public RelayCommand<object> SignInCommand
        {
            get
            {
                // return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                //            SignInInplementation, o => CanExecuteCommand()));
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.Randomizer);
                           }));
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
    }
}
