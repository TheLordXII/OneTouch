using MobileApp.ViewModel;
using Xamarin.Forms;
using MobileApp.Services;
using System.Diagnostics;

namespace OneTouch.View
{
    public partial class DrinksAvailableView : ContentPage
    {
        DrinksAvailableVM vm = new DrinksAvailableVM();
        public DrinksAvailableView()
        {
            
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vm.RefreshCommand.Execute(null);
            base.OnAppearing();
            var currentPageKeyString = Locator.DrinksAvailableView;
                //.GetInstance<INavigationService>()
                //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
