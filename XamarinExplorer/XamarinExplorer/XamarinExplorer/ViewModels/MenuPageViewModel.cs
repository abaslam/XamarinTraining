namespace XamarinExplorer.ViewModels
{
    using System.Collections.ObjectModel;
    using Prism.Commands;
    using Prism.Navigation;
    using Xamarin.Forms;
    using XamarinExplorer.Models;
    using XamarinExplorer.Views;

    public class MenuPageViewModel : ViewModelBase
    {
        protected const string RootUriFormat = "{0}/MainPage";
        private ObservableCollection<MenuModel> menuItems;
        private MenuModel selectedMenuItem;

        public MenuPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.MenuSelectedCommand = new DelegateCommand(this.MenuSelected);
            this.InitMenus();
        }

        public DelegateCommand MenuSelectedCommand { get; set; }

        public ObservableCollection<MenuModel> MenuItems
        {
            get => this.menuItems;
            set => this.SetProperty(ref this.menuItems, value);
        }

        public MenuModel SelectedMenuItem
        {
            get => this.selectedMenuItem;
            set => this.SetProperty(ref selectedMenuItem, value);
        }

        public async void MenuSelected()
        {
            await this.NavigationService.NavigateAsync(this.SelectedMenuItem.Page);
        }

        private void InitMenus()
        {
            string rootUri = string.Format(RootUriFormat, nameof(NavigationPage));
            this.MenuItems = new ObservableCollection<MenuModel>
            {
                new MenuModel{ Label = "Basic Controls", Page =$"{rootUri}/{nameof(BasicControlsPage)}" }
            };
        }
    }
}
