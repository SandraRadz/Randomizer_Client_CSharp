using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Randomizer_Client.Tools.Managers;
using Randomizer_Client.Tools.DataStorage;
using Randomizer_Client.Tools.Navigation;
using Randomizer_Client.ViewModels;

namespace Randomizer_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            StationManager.Initialize(new DataBaseStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            StationManager.CloseApp();
        }
    }
}
