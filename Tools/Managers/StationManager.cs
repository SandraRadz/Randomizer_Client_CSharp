﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Randomizer_Client.Models;
using Randomizer_Client.Tools.DataStorage;

namespace Randomizer_Client.Tools.Managers
{
    internal static class StationManager
    {
        public static event Action StopThreads;

        private static IDataStorage _dataStorage;

        internal static User CurrentUser { get; set; }
        internal static ObservableCollection<Request> HistoryList { get; set; }

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
