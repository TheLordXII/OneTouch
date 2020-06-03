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
            NavigationService.Configure(Locator.LoginPage, typeof(LoginPage));
            NavigationService.Configure(Locator.HomeScreen, typeof(HomeScreen));
            NavigationService.Configure(Locator.DetailsPage, typeof(DetailsPage));
            NavigationService.Configure(Locator.Friends, typeof(Friends));
            NavigationService.Configure(Locator.MasterPage, typeof(MasterPage));

            var firstPage = ((NavigationService)NavigationService).SetRootPage(Locator.LoginPage);

            MainPage = firstPage;
        }

        public static INavigationService NavigationService
        {
            get;
        } = new NavigationService();

        public static User User
        {
            get;
            set;
        } = new User();

        protected override void OnStart()
        {
           //kann leer bleiben
        }

        protected override void OnSleep()
        {
            //was passiert wenn die App in den Hintergrund geschickt wird?
            //kann leer bleiben
        }

        protected override void OnResume()
        {
            //Was passiert wenn man sie aus der Queue holt?
            //kann leer bleiben
        }
    }
}
