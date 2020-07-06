using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.Services;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class ConfigView : ContentPage
    {
        public ConfigView()
        {
            var vm = new ConfigVM();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.ConfigView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
