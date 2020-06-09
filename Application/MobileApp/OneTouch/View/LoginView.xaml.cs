using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MobileApp.ViewModel;
using MobileApp.Services;

namespace OneTouch.View
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            var vm = new LoginVM();
            this.BindingContext = vm;

            InitializeComponent();
        }


    }
}
