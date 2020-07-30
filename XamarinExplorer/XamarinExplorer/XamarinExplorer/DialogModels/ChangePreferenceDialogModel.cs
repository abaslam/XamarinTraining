using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using XamarinExplorer.Models;

namespace XamarinExplorer.DialogModels
{
    public class ChangePreferenceDialogModel : DialogModelBase
    {
        private SettingsModel settings;

        public ChangePreferenceDialogModel(INavigationService navigationService) : base(navigationService)
        {
            this.SavePreferenceCommand = new DelegateCommand(this.SavePreference);
            this.ClosePreferenceCOmmand = new DelegateCommand(this.ClosePreference);
        }

        private void ClosePreference()
        {
            this.ExecuteRequestClose(null);
        }

        private void SavePreference()
        {
            var preferenceParameters = new DialogParameters
            {
                {"Preference", this.Settings }
            };

            this.ExecuteRequestClose(preferenceParameters);
        }

        public DelegateCommand SavePreferenceCommand { get; set; }
        public DelegateCommand ClosePreferenceCOmmand { get; set; }

        public SettingsModel Settings
        {
            get => settings;
            set => this.SetProperty(ref this.settings, value);
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var settings = parameters.GetValue<SettingsModel>("Preferences");

            this.Settings = new SettingsModel { SendWeeklyEmail = settings.SendWeeklyEmail, ShowWelcomeScreen = settings.ShowWelcomeScreen };
        }
    }
}
