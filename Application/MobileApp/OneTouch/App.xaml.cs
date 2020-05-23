    using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OneTouch.View;
using GalaSoft.MvvmLight.Ioc;
using MobileApp.Services;
using MobileApp.FürmichbistdueinfachkeinModel;

/// <summary>
/// Die App Klasse steuert das grundsätzliche Verhalten der App ihr Bonobos!
/// Aufgaben:
/// was passiert wenn die App in den Hintergrund geschickt wird?
/// was passiert beim Startup?
/// Was passiert wenn man sie aus der Queue holt?
/// </summary>
namespace OneTouch
{
    public partial class App : Application
    {
        /// <summary>
        /// Konstruktor für die App Klasse
        /// </summary>
        public App()
        {
            //InitializeComponent();
            //var nav = new NavigationService();
            NavigationService.Configure(Locator.LoginPage, typeof(LoginPage));
            NavigationService.Configure(Locator.HomeScreen, typeof(HomeScreen));
            NavigationService.Configure(Locator.DetailsPage, typeof(DetailsPage));


            //SimpleIoc.Default.Register<INavigationService>(() => nav);

            //var firstPage = new NavigationPage(new LoginPage(nav));
            //NavigationService.Initialize(firstPage);

            var firstPage = ((NavigationService)NavigationService).SetRootPage(Locator.LoginPage);


            MainPage = firstPage;
            //MainPage = new NavigationPage(new LoginPage(nav));
            //MainPage = new NavigationPage(new HomeScreen());
        }

        public static INavigationService NavigationService
        {
            get;
        } = new NavigationService();

        public static User User
        {
            get;
            set;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
