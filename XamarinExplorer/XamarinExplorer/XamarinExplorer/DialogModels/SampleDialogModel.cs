using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace XamarinExplorer.DialogModels
{
    public class SampleDialogModel : DialogModelBase
    {
        public SampleDialogModel(INavigationService navigationService) : base(navigationService)
        {
            this.CloseDialogCommand = new DelegateCommand(this.CloseDialog);
        }

        private void CloseDialog()
        {
            this.ExecuteRequestClose(null);
        }

        public DelegateCommand CloseDialogCommand { get; set; }
    }
}
