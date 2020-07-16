using Prism;
using Prism.Ioc;
using XamarinExplorer.ViewModels;
using XamarinExplorer.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinExplorer
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
            Xamarin.Forms.Device.SetFlags(new string[] { "RadioButton_Experimental" });
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"/MenuPage/{nameof(NavigationPage)}/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BasicControlsPage, BasicControlsPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
