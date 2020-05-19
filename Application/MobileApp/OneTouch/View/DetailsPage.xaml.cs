﻿using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;
using MobileApp.Services;
using System.Diagnostics;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace OneTouch.View
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(object[] para)
        {
            Drink selectedDrink = (Drink) para[0];
            User user = (User)para[1];

            var vm = new DetailsPageVM(selectedDrink, user);
            
            this.BindingContext = vm;
            InitializeComponent();
        ;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.DetailsPage;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}