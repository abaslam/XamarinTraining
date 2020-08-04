using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services.Dialogs;
using XamarinExplorer.Events;

namespace XamarinExplorer.ViewModels
{
    public class BusyIndicatorPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IDialogService dialogService;

        public BusyIndicatorPageViewModel(IEventAggregator eventAggregator,IDialogService dialogService,INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Busy Indicator";
            this.LoadCommand = new DelegateCommand(this.Load);
            this.eventAggregator = eventAggregator;
            this.dialogService = dialogService;
        }

        private async void Load()
        {
            this.dialogService.ShowDialog("BusyIndicatorDialog");
            await Task.Delay(3000);
            this.eventAggregator.GetEvent<HideIndicatorDialogEvent>().Publish();
        }

        public DelegateCommand LoadCommand { get; set; }
    }
}
