
﻿using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;
using MobileApp.Services;
using System.Diagnostics;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace OneTouch.View
{
    public partial class Friends : ContentPage
    {
        public Friends()
        {
            var vm = new FriendsVM();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.Friends;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}

