    using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OneTouch.View;
using GalaSoft.MvvmLight.Ioc;
using MobileApp.Services;

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
            var nav = new NavigationService();
            nav.Configure(Locator.LoginPage, typeof(LoginPage));
            nav.Configure(Locator.HomeScreen, typeof(HomeScreen));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var firstPage = new NavigationPage(new LoginPage(nav));

            nav.Initialize(firstPage);

            MainPage = firstPage;
            //MainPage = new NavigationPage(new LoginPage(nav));
            //MainPage = new NavigationPage(new HomeScreen());
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
