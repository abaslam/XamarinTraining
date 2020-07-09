using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinTraining.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            ViewSettingsPageCommand = new DelegateCommand(ViewSettingsPage);
            AddUserCommand = new DelegateCommand<User>(this.AddUser);
            NameChangedCommand = new DelegateCommand<string>(this.NameChanged);
        }

        public DelegateCommand ViewSettingsPageCommand { get; set; }
        public User SelectedUser { get; set; } = new User { UserId = 1, UserName = "Test" };

        public DelegateCommand<User> AddUserCommand { get; set; }
        public DelegateCommand<string> NameChangedCommand { get; set; }

        private async void ViewSettingsPage()
        {
            var parameters = new NavigationParameters
            {
                {"UserId", 100 }
            };

            await this.NavigationService.NavigateAsync("SettingsPage", parameters);
        }

        private void AddUser(User user)
        {
            var newUser = user.UserName;
        }

        private void NameChanged(string text)
        {
            var value = text;
        }

        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
        }
    }
}
