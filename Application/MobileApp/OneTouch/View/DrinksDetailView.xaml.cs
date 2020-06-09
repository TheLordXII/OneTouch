using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;
using MobileApp.Services;
using System.Diagnostics;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace OneTouch.View
{
    public partial class DrinksDetailView : ContentPage
    {
        public DrinksDetailView(Drink selectedDrink)
        {
            var vm = new DrinksDetailVM(selectedDrink);
            
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.DrinksDetailView;
            //.GetInstance<INavigationService>()
            //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
