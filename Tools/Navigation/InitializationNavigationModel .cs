using System;
using RandomizerView = Randomizer_Client.Views.Randomizer;
using SignUpView = Randomizer_Client.Views.SignUp;
using SignInView = Randomizer_Client.Views.SignIn;
using HistoryView = Randomizer_Client.Views.History;


namespace Randomizer_Client.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel 
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.SignIn:
                    ViewsDictionary.Add(viewType, new SignInView());
                    break;
                case ViewType.SignUp:
                    ViewsDictionary.Add(viewType, new SignUpView());
                    break;
                case ViewType.Randomizer:
                    ViewsDictionary.Add(viewType, new RandomizerView());
                    break;
                case ViewType.History:
                    ViewsDictionary.Add(viewType, new HistoryView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
