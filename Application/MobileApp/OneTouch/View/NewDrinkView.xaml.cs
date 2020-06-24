using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class NewDrinkView : ContentPage
    {
        public NewDrinkView()
        {
            var vm = new NewDrinkVM();
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}
