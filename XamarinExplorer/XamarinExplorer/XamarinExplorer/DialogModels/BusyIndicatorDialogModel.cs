using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;
using Prism.Navigation;
using XamarinExplorer.Events;

namespace XamarinExplorer.DialogModels
{
    public class BusyIndicatorDialogModel : DialogModelBase
    {
        private readonly IEventAggregator eventAggregator;

        public BusyIndicatorDialogModel(IEventAggregator eventAggregator,INavigationService navigationService) : base(navigationService)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<HideIndicatorDialogEvent>().Subscribe(this.CloseDialog);
        }

        private void CloseDialog()
        {
            this.ExecuteRequestClose(null);
            this.eventAggregator.GetEvent<HideIndicatorDialogEvent>().Unsubscribe(this.CloseDialog);
        }
    }
}
