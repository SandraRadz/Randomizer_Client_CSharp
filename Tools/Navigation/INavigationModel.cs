namespace Randomizer_Client.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
        Randomizer,
        History
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}