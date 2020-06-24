using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.Services;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class AboutView : ContentPage
    {
        public AboutView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.AboutView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
