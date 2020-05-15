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

            vm.DisplayInvalidLoginPrompt+= ()=> DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.DisplaySuccessfulLoginPrompt += () => DisplayAlert("Success", "You've been logged in", "OK"); 
            InitializeComponent();
        }


    }
}
