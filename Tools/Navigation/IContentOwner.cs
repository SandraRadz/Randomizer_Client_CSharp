using System.Windows.Controls;

namespace Randomizer_Client.Tools.Navigation
{
    interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
