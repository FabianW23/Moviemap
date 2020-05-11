using Prism;
using Prism.Ioc;
using Moviemap.Prism.ViewModels;
using Moviemap.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Moviemap.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Moviemap.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CinemasPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CinemasPage, CinemasPageViewModel>();
        }
    }
}
