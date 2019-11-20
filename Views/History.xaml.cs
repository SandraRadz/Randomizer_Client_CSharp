using Randomizer_Client.Tools.Navigation;
using Randomizer_Client.ViewModels;

namespace Randomizer_Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class History: INavigatable
    {
        public History()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }

        
    }
}
