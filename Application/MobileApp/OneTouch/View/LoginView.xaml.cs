using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MobileApp.ViewModel;
using MobileApp.Services;
using System.Diagnostics;

namespace OneTouch.View
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            var vm = new LoginVM();
            this.BindingContext = vm;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.LoginView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
