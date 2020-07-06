using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.Services;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            var vm = new MasterPageVM();
            this.BindingContext = vm;
            InitializeComponent();
            Detail = new NavigationPage(new DrinksAvailableView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.MasterPage;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
