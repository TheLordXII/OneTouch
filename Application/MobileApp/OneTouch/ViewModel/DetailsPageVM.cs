using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class DetailsPageVM : ViewModelBase
    {
        private IDrinkService _drinkService;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

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

        //funktion rausgenommen
        private async Task TryOrderDrink()
        {
            await _dialogService.ShowMessage("You want to order a drink",
            "Please make sure, there is a glass under the output of the OneTouch.", "There is a glass!", "There is no glass!", async returnvalue =>
            {
                if (returnvalue)
                {
                    await OrderDrink();

                }
                else
                {
                    await _dialogService.ShowMessage ("Can't make drink", "Unfortunately the OneTouch is not able to make a Cocktail without a glass under the output.");
                }
            },
            false, false);

        }

        private async Task OrderDrink()
        {
            ReturnCode statusCode = ReturnCode.fatalError;
            statusCode = await _drinkService.orderDrink(drink.ID);
            switch (statusCode)
            {
                case ReturnCode.success:
                    string title = String.Format("{0} is made", drink.Name);
                    Task.Run(() => _dialogService.ShowMessage(title, "Enjoy your Cocktail!"));
                    
                    await _navigationService.GoBack();
                    break;
                case ReturnCode.orderError:
                    await _dialogService.ShowMessage("Error", "Some unexpected error occurred while ordering, please try again later.");
                    break;
                case ReturnCode.countError:
                    await _dialogService.ShowMessage("Error", "Some unexpected error occurred while updating the statistics, please try again later.");
                    break;
                default:
                    await _dialogService.ShowMessage("Error", "Some unexpected error occurred, please try again later.");
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
            Debug.WriteLine("lol foreach ist cool");
        }

        public DetailsPageVM(Drink selectedDrink, IDrinkService drinkService, IDialogService dialogService)
        {
            drink = selectedDrink;
            _drinkService = drinkService;
            _dialogService = dialogService;
            _navigationService = App.NavigationService;
            Debug.WriteLine(drink.Name);
            drink.Ingredients = new ObservableCollection<Ingredient>();

            Task.Run(() => GetIngredients());
        }


        public DetailsPageVM(Drink selectedDrink): this(selectedDrink ,  new DrinkService(), new DialogService())
        {

        }
    }
}
