using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using XamarinExplorer.Models;

namespace XamarinExplorer.ViewModels
{
    public class EnableDisablePageViewModel : ViewModelBase
    {
        private SettingsModel settings;
        public EnableDisablePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Enable Disable ";
            this.Settings = new SettingsModel();
        }

        public SettingsModel Settings
        {
            get => settings;
            set => this.SetProperty(ref this.settings, value);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            this.Settings.ShowWelcomeScreen = true;
        }
    }
}
