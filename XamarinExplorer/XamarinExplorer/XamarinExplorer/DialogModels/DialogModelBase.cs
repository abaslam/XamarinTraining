using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;

namespace XamarinExplorer.DialogModels
{
    public class DialogModelBase : BindableBase, IDialogAware
	{
		private string title;

		public DialogModelBase(INavigationService navigationService)
		{
			this.NavigationService = navigationService;
		}

		public event Action<IDialogParameters> RequestClose;

		public string Title
		{
			get { return this.title; }
			set { this.SetProperty(ref this.title, value); }
		}

		protected INavigationService NavigationService { get; private set; }

		public bool CanCloseDialog()
		{
			return true;
		}

		public virtual async void OnDialogOpened(IDialogParameters parameters)
		{
			// Does nothing by default..
			await Task.FromResult<object>(null);
			return;
		}

		public virtual void OnDialogClosed()
		{
			// Does nothing by default..
		}

		protected void ExecuteRequestClose(IDialogParameters dialogParameters)
		{
			this.RequestClose?.Invoke(dialogParameters);
		}
	}
}
