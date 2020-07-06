using System;
using System.Collections.Generic;
using System.Diagnostics;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;
using OneTouch.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class FriendsDetailView : ContentPage
    {
        public FriendsDetailView(User selectedUser)
        {
            var vm = new FriendsDetailVM(selectedUser);
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.FriendsDetailView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
