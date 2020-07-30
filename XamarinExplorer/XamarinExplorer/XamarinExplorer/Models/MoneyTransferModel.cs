using System;
using System.Collections.Generic;
using System.Text;
using XamarinExplorer.Models;

namespace XamarinExplorer.Dialogs
{
    public class MoneyTransferModel : ModelBase
    {
        private decimal amount;
        private bool neft;
        private string neftCode;
        private string impsCode;

        public decimal Amount
        {
            get => amount;
            set => this.SetProperty(ref amount, value);
        }

        public bool Neft
        {
            get => neft;
            set => this.SetProperty(ref neft, value);
        }

        public string NeftCode
        {
            get => neftCode;
            set => this.SetProperty(ref neftCode, value);
        }

        public string ImpsCode
        {
            get => impsCode;
            set => this.SetProperty(ref impsCode, value);
        }
    }
}
