using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MobileApp.ViewModel;
using MobileApp.Services;

namespace OneTouch.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginPageVM();
            this.BindingContext = vm;

            InitializeComponent();
        }


    }
}
