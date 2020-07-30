using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using XamarinExplorer.Dialogs;

namespace XamarinExplorer.ViewModels
{
    public class ConverterPageViewModel : ViewModelBase
    {
        private MoneyTransferModel transfer;
        public ConverterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Converter Page";
            this.transfer = new MoneyTransferModel();
        }

        public MoneyTransferModel Transfer
        {
            get => transfer;
            set => this.SetProperty(ref this.transfer, value);
        }
    }
}
