using MobileApp.ViewModel;
using Xamarin.Forms;
using MobileApp.Services;
using System.Diagnostics;

namespace OneTouch.View
{
    public partial class DrinksView : ContentPage
    {
        public DrinksView()
        {
            var vm = new DrinksVM();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = Locator.DrinksView;
                //.GetInstance<INavigationService>()
                //.CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
