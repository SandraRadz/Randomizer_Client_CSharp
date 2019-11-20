using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Randomizer_Client.Tools;
using Randomizer_Client.Tools.Managers;

namespace Randomizer_Client.ViewModels
{
    class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;


        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
