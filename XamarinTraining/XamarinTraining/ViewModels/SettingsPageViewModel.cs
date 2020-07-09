using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace XamarinTraining.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private int userId;

        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Setting Page";
            this.ViewProfilePageCommand = new DelegateCommand(this.ViewProfilePage);
            this.ViewProfilePageAdvanceCommand = new DelegateCommand(this.ViewProfilePageAdvance);
        }

        public DelegateCommand ViewProfilePageCommand { get; set; }
        public DelegateCommand ViewProfilePageAdvanceCommand { get; set; }

        public int UserId
        {
            get { return this.userId; }
            set { this.SetProperty(ref this.userId, value); }
        }

        public override void Initialize(INavigationParameters parameters)
        {
            this.UserId = parameters.GetValue<int>("UserId");
        }

        public async void ViewProfilePage()
        {
            await this.NavigationService.NavigateAsync("ProfilePage");
        }

        public async void ViewProfilePageAdvance()
        {
            await this.NavigationService.NavigateAsync("../ProfilePage");
        }

    }
}
