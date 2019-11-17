using Randomizer_Client.Tools.Navigation;
using Randomizer_Client.ViewModels;

namespace Randomizer_Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Randomizer: INavigatable
    {
        public Randomizer()
        {
            InitializeComponent();
            DataContext = new RandomizerViewModel();
        }
    }
}
