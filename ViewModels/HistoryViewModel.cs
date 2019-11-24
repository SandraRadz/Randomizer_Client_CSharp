using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer_Client.Models;
using Randomizer_Client.Tools;
using Randomizer_Client.Tools.Managers;
using Randomizer_Client.Tools.Navigation;

namespace Randomizer_Client.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {

        private int _from;
        private int _to;
        private int _count;
        private DateTime _time;

        private RelayCommand<object> _signOutCommand;
        private RelayCommand<object> _goBackCommand;

        private ICollection<Request> _requests;

        internal HistoryViewModel()
        {
            _requests = StationManager.HistoryList;
        }
        public int From
        {
            get { return _from; }
            set { _from = value; }
        }
        public int To
        {
            get { return _to; }
            set { _to = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public ICollection<Request> Requests
        {
            get { return _requests; }
            set
            {
                _requests = value; 
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> SignOutCommand
        {
            get
            {
                return _signOutCommand ?? (_signOutCommand = new RelayCommand<object>(
                           o =>
                           {
                               StationManager.CurrentUser = null;
                               StationManager.HistoryList = null;
                               NavigationManager.Instance.Navigate(ViewType.SignIn);
                           }));
            }
        }


        public RelayCommand<object> GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.Randomizer);
                           }));
            }
        }

    }
}
