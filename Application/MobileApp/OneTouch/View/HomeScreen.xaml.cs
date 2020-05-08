using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class HomeScreen : ContentPage
    {
        public HomeScreen()
        {
            var vm = new HomeScreenVM();
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}
