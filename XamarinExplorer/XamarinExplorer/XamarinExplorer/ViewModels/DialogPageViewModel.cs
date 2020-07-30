using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using XamarinExplorer.Models;

namespace XamarinExplorer.ViewModels
{
    public class DialogPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService pageDialogService;
        private readonly IDialogService dialogService;
        private SettingsModel settings;

        public DialogPageViewModel(IPageDialogService pageDialogService,IDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Dialogs";
            this.pageDialogService = pageDialogService;
            this.dialogService = dialogService;

            this.OpenDialogCommand = new DelegateCommand(this.OpenDialog);

            this.ChangePreferenceCommand = new DelegateCommand(this.ChangePreference);
            this.AlertCommand = new DelegateCommand(ShowAlert);
            this.ConfirmCommand = new DelegateCommand(ShowConfirm);
            this.ActionSheetCommand = new DelegateCommand(ShowActionSheet);
            this.PromptCommand = new DelegateCommand(ShowPrompt);
        }

        private void ShowPrompt()
        {
            //var name = await this.pageDialogService.Pro
        }

        private async void ShowActionSheet()
        {
            var colors = new[] { "Blue", "Red", "Green" };

            var color = await this.pageDialogService.DisplayActionSheetAsync("Choose Color", "Cancel", "Delete", colors);

            if (!string.IsNullOrWhiteSpace(color))
            {
                await this.pageDialogService.DisplayAlertAsync("Success", $"Your choose {color}", "Ok");
            }
        }

        private async void ShowConfirm()
        {
           var confirm= await this.pageDialogService.DisplayAlertAsync("Confirm", "Are you sure want to delete?", "Yes", "No");

            if (confirm)
            {
                await this.pageDialogService.DisplayAlertAsync("Success", "Your choose to delete", "Ok");
            }
        }

        private async void ShowAlert()
        {
            await this.pageDialogService.DisplayAlertAsync("Success", "Your order has been success fully saved", "Ok");
        }

        private void ChangePreference()
        {
            var preferenceParameters = new DialogParameters
            {
                { "Preferences",  this.Settings}
            };
            this.dialogService.ShowDialog("ChangePreferenceDialog", preferenceParameters, (result)=> {
                if (result.Parameters.ContainsKey("Preference"))
                {
                    this.Settings = result.Parameters.GetValue<SettingsModel>("Preference");
                }
            });
        }

        private void OpenDialog()
        {
            this.dialogService.ShowDialog("SampleDialog");
        }

        public override void Initialize(INavigationParameters parameters)
        {
            this.Settings = new SettingsModel { SendWeeklyEmail = true, ShowWelcomeScreen = true };
        }

        public DelegateCommand OpenDialogCommand { get; set; }

        public DelegateCommand ChangePreferenceCommand { get; set; }

        public DelegateCommand AlertCommand { get; set; }

        public DelegateCommand ConfirmCommand { get; set; }

        public DelegateCommand ActionSheetCommand { get; set; }

        public DelegateCommand PromptCommand { get; set; }

        public SettingsModel Settings
        {
            get => settings;
            set => this.SetProperty(ref this.settings, value);
        }
    }
}
