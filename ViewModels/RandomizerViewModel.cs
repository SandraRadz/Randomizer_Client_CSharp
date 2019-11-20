using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Randomizer_Client.Tools;
using Randomizer_Client.Tools.Managers;
using Randomizer_Client.Tools.Navigation;

namespace Randomizer_Client.ViewModels
{
    class RandomizerViewModel : BaseViewModel
    {
        private int _from;
        private int _to;
        private string _result;

        private RelayCommand<object> _signOutCommand;
        private RelayCommand<object> _generateCommand;
        private RelayCommand<object> _historyCommand;


        public int From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged();
            }

        }

        public int To
        {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged();
            }

        }


        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
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
                               NavigationManager.Instance.Navigate(ViewType.SignIn);
                           }));
            }
        }

        public RelayCommand<object> GenerateCommand
        {
            get
            {
                return _generateCommand ?? (_generateCommand = new RelayCommand<object>(
                           GenerateInplementation, o => CanExecuteCommand()));
                           
            }
        }


        public bool CanExecuteCommand()
        {
            return _to>=_from;
        }

        public async void GenerateInplementation(object obj)
        {
            Result = "";
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {

                int[] array = new int[_to - _from + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = i+_from;
                }
                
                var rng = new Random();
                rng.Shuffle(array);
                foreach (var item in array)
                {
                    Result += item + "\n";
                }
            });
            LoaderManager.Instance.HideLoader();
        }


        public RelayCommand<object> HistoryCommand
        {
            get
            {
                return _historyCommand ?? (_historyCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.History);
                           }));
            }


        }



    }

    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}

