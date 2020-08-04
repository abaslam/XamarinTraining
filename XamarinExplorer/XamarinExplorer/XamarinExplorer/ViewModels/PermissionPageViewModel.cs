using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace XamarinExplorer.ViewModels
{
    public class PermissionPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService pageDialogService;

        public PermissionPageViewModel(IPageDialogService pageDialogService,INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Permissions";
            this.ShowLocationCommand = new DelegateCommand(this.ShowLocation);
            this.pageDialogService = pageDialogService;
        }

        private async void ShowLocation()
        {
			var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

			if (status != PermissionStatus.Granted)
			{
				status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
			}

			if (status == PermissionStatus.Granted)
			{
				try
				{
					var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
					await this.pageDialogService.DisplayAlertAsync("Location", $"Your location at {location.Longitude}, {location.Latitude}", "Ok");

					var options = new MapLaunchOptions { Name = "My Location" };

					await Map.OpenAsync(location, options);
				}
				catch (Exception ex)
				{

				}
			}
		}

        public DelegateCommand ShowLocationCommand { get; set; }
    }
}
