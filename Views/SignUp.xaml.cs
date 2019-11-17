using System.Windows;
using Randomizer_Client.Tools.Navigation;
using Randomizer_Client.ViewModels;

namespace Randomizer_Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignUp : INavigatable
    {
        public SignUp()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
