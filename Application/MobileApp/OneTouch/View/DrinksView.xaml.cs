using MobileApp.ViewModel;
using Xamarin.Forms;
using MobileApp.Services;
using System.Diagnostics;

namespace OneTouch.View
{
    public partial class DrinksView : ContentPage
    {
        DrinksVM vm = new DrinksVM();
        public DrinksView()
        {
            
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vm.RefreshCommand.Execute(null);
            base.OnAppearing();
            var currentPageKeyString = Locator.DrinksView;
                //.GetInstance<INavigationService>()
                //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
