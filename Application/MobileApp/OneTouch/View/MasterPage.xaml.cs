using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneTouch.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            var vm = new MasterPageVM();
            this.BindingContext = vm;
            InitializeComponent();
            Detail = new NavigationPage(new HomeScreen());
            IsPresented = false;
            
        }


    }

}
