using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OneTouch.View;

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
            InitializeComponent();

            MainPage = new LoginPage();
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
