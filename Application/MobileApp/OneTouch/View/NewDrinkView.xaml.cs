using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.Services;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class NewDrinkView : ContentPage
    {
        public NewDrinkView()
        {
            var vm = new NewDrinkVM();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.NewDrinkView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
