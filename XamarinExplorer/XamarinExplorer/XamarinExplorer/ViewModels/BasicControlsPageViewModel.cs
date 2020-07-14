using Prism.Navigation;

namespace XamarinExplorer.ViewModels
{
    public class BasicControlsPageViewModel : ViewModelBase
    {
        public BasicControlsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Basic Controls";
        }
    }
}
