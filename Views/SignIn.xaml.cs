using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Randomizer_Client.Tools.Navigation;
using Randomizer_Client.ViewModels;

namespace Randomizer_Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignIn : INavigatable
    {
        public SignIn()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
