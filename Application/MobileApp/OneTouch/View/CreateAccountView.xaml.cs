using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.Services;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class CreateAccountView : ContentPage
    {
        public CreateAccountView()
        {
            var vm = new CreateAccountVM();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.CreateAccountView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
