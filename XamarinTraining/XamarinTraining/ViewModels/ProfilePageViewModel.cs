using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace XamarinTraining.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        public ProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Profile Page";
            this.ViewMainPageCommand = new DelegateCommand(this.ViewMainPage);
        }

        public DelegateCommand ViewMainPageCommand { get; set; }

        public async void ViewMainPage()
        {
            //await this.NavigationService.NavigateAsync("/RootPage/NavigationPage/MainPage");

            //await this.NavigationService.GoBackAsync();

            await this.NavigationService.GoBackToRootAsync();
        }
    }
}
