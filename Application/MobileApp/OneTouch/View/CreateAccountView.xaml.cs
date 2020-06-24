using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class CreateAccountView : ContentPage
    {
        public CreateAccountView()
        {
            var vm = new CreateAccountVM();
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}
