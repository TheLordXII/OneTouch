﻿using System;
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
    public class DetailsPageVM : ViewModelBase
    {
        private IDrinkService _drinkService;
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
                                            await TryOrderDrink();
                                        }));

            }
        }

        private async Task TryOrderDrink()
        {
            await SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("You want to order a drink",
            "Please make sure, there is a glass under the output of the OneTouch.", "There is a glass!", "There is no glass!", async returnvalue =>
            {
                if (returnvalue)
                {
                    await OrderDrink();

                }
                else
                {
                    await SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage ("Can't make drink", "Unfortunately the OneTouch is not able to make a Cocktail without a glass under the output.");
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
                    Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage(title, "Enjoy your Cocktail!"));
                    await _navigationService.GoBack();
                    //await _navigationService.NavigateAsync(Locator.HomeScreen, user);
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

        public DetailsPageVM(Drink selectedDrink, IDrinkService drinkService)
        {
            drink = selectedDrink;
            _drinkService = drinkService;
            var dialogservice = DependencyService.Get<IDialogService>();
            SimpleIoc.Default.Register<IDialogService>(() => dialogservice);
            _navigationService = App.NavigationService;
            Debug.WriteLine(drink.Name);
            drink.Ingredients = new ObservableCollection<Ingredient>();

            Task.Run(() => GetIngredients());
        }


        public DetailsPageVM(Drink selectedDrink): this(selectedDrink , new DrinkService())
        {

        }
    }
}
