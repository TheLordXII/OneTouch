using System;
using System.Collections.Generic;
using MobileApp.ViewModel;
using Xamarin.Forms;

namespace OneTouch.View
{
    public partial class ConfigView : ContentPage
    {
        public ConfigView()
        {
            var vm = new ConfigVM();
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}
