using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.Services;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class UserView : ContentPage
    {
        public UserView()
        {
            var vm = new UserVM();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.UserView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
