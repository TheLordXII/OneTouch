using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;
using OneTouch;
using Xamarin.Forms;

namespace MobileApp.ViewModel
{
    public class DrinksDetailVM : ViewModelBase
    {
        private readonly IDrinkService _drinkService;
        private readonly INavigationService _navigationService;

        private Drink _drink;

        public Drink drink
        {
            get
            {
                return _drink;
            }
            set
            {
                if (_drink == value)
                {
                    return;
                }
                _drink = value;
                RaisePropertyChanged("SelectedDrink");
            }
        }

        private RelayCommand _OrderCommand;

        public RelayCommand OrderCommand
        {
            get
            {
                return _OrderCommand
                ?? (_OrderCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await OrderDrink();
                                        }));

            }
        }

        private async Task OrderDrink()
        {
            ReturnCode statusCode = ReturnCode.fatalError;
            statusCode = await _drinkService.orderDrink(drink.ID);
            switch (statusCode)
            {
                case ReturnCode.success:
                    string title = String.Format("{0} is made", drink.Name);
                    Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage(title, "Enjoy your Cocktail!"));
                    await _navigationService.GoBack();
                    break;
                case ReturnCode.orderError:
                    await SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occurred while ordering, please try again later.");
                    break;
                case ReturnCode.countError:
                    await SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occurred while updating the statistics, please try again later.");
                    break;
                default:
                    await SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occurred, please try again later.");
                    break;
            }

        }

        private async Task GetIngredients()
        {
            drink.Ingredients.Clear();
            var ingredients =  await _drinkService.GetIngredients(drink.ID);
            foreach (var ingredient in ingredients)
            {
                drink.Ingredients.Add(ingredient);
            }
            Debug.WriteLine("got ingredients");
        }

        public DrinksDetailVM(Drink selectedDrink, IDrinkService drinkService)
        {
            drink = selectedDrink;
            _drinkService = drinkService;
            _navigationService = App.NavigationService;

            drink.Ingredients = new ObservableCollection<Ingredient>();
            Task.Run(() => GetIngredients());
        }



        public DrinksDetailVM(Drink selectedDrink): this(selectedDrink , new DrinkService())
        {
        }
    }
}
