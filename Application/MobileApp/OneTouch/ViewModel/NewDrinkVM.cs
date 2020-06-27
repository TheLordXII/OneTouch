using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class NewDrinkVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        IDrinkService _drinkService;
        INavigationService _navigationService;

        private Drink _drink;
        public Drink Drink
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
                RaisePropertyChanged("Drink");
            }
        }

        private ObservableCollection<Ingredient> _IngredientList;
        public ObservableCollection<Ingredient> IngredientList
        {
            get { return _IngredientList; }
            set
            {
                if (_IngredientList == value)
                {
                    return;
                }
                _IngredientList = value;
                RaisePropertyChanged("IngredientList");
            }
        }

        public List<Ingredient> IngredientSelection
        {
            get;
            set;
        }

        private double _TotalAmount;
        public double TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                int res=0;
                for (int i = 0; i < 6; i++)
                {
                    res += Drink.Ingredients[i].AmountInt; 
                }
                _TotalAmount = res;
                RaisePropertyChanged("TotalAmount");
            }
        }

        private double _Slider0Command;

        public double Slider0Command
        {
            get
            {
                return _Slider0Command;
            }
            set
            {
                _Slider0Command = value;
                SetSlider0Value(value);
                RaisePropertyChanged("Slider0Command");
            }
        }

        private void SetSlider0Value(double value)
        {
            Drink.Ingredients[0].AmountInt = ((int)value / 20) * 20;
            TotalAmount++;
        }

        private double _Slider1Command;

        public double Slider1Command
        {
            get
            {
                return _Slider1Command;
            }
            set
            {
                _Slider1Command = value;
                SetSlider1Value(value);
                RaisePropertyChanged("Slider0Command");
            }
        }

        private void SetSlider1Value(double value)
        {
            Drink.Ingredients[1].AmountInt = ((int)value / 20) * 20;
            TotalAmount++;
        }

        private double _Slider2Command;

        public double Slider2Command
        {
            get
            {
                return _Slider2Command;
            }
            set
            {
                _Slider2Command = value;
                SetSlider2Value(value);
                RaisePropertyChanged("Slider0Command");
            }
        }

        private void SetSlider2Value(double value)
        {
            Drink.Ingredients[2].AmountInt = ((int)value / 20) * 20;
            TotalAmount++;
        }

        private double _Slider3Command;

        public double Slider3Command
        {
            get
            {
                return _Slider3Command;
            }
            set
            {
                _Slider3Command = value;
                SetSlider3Value(value);
                RaisePropertyChanged("Slider0Command");
            }
        }

        private void SetSlider3Value(double value)
        {
            Drink.Ingredients[3].AmountInt = ((int)value / 20) * 20;
            TotalAmount++;
        }

        private double _Slider4Command;

        public double Slider4Command
        {
            get
            {
                return _Slider4Command;
            }
            set
            {
                _Slider4Command = value;
                SetSlider4Value(value);
                RaisePropertyChanged("Slider0Command");
            }
        }

        private void SetSlider4Value(double value)
        {
            Drink.Ingredients[4].AmountInt = ((int)value / 20) * 20;
            TotalAmount++;
        }

        private double _Slider5Command;

        public double Slider5Command
        {
            get
            {
                return _Slider5Command;
            }
            set
            {
                _Slider5Command = value;
                SetSlider5Value(value);
                RaisePropertyChanged("Slider0Command");
            }
        }

        private void SetSlider5Value(double value)
        {
            Drink.Ingredients[5].AmountInt = ((int)value / 20) * 20;
            TotalAmount++;
        }

        private RelayCommand _CreateDrinkCommand;

        public RelayCommand CreateDrinkCommand
        {
            get
            {
                return _CreateDrinkCommand
                ?? (_CreateDrinkCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await CreateDrink();
                                        }));

            }
        }

        private async Task CreateDrink()
        {
            int numIngredients = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Drink.Ingredients[i].Name != null)
                {
                    numIngredients++;
                }
            }
            //wichtige felder ausgefüllt
            if (Drink.Name != null
                && Drink.Description != null
                && numIngredients != 0)
            {
                
                var createTask = _drinkService.CreateDrink(Drink);

                ReturnCode statusCode = await createTask;

                await Task.WhenAll(createTask);
                if (statusCode == ReturnCode.success)
                {
                    await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Success", "Your drink will be added to the database."));
                    await _navigationService.NavigateAsync(Locator.MasterPage);
                }
                else
                {
                    await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occured. Please try again later."));
                }
            }
            else
            {
                await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some information is missing, please fill out name, description and at least one ingredient."));
            }
        }

        public NewDrinkVM(): this (new DrinkService())
        {
        }

        public NewDrinkVM(IDrinkService drinkService)
        {
            _drinkService = drinkService;
            _navigationService = App.NavigationService;
            IngredientList = new ObservableCollection<Ingredient>();
            IngredientList.Add(new Ingredient { AmountInt = 0 });
            IngredientList.Add(new Ingredient { AmountInt = 0 });
            IngredientList.Add(new Ingredient { AmountInt = 0 });
            IngredientList.Add(new Ingredient { AmountInt = 0 });
            IngredientList.Add(new Ingredient { AmountInt = 0 });
            IngredientList.Add(new Ingredient { AmountInt = 0 });

            Drink = new Drink { Name ="-", Description="-", Ingredients = IngredientList};
            IngredientSelection constants = new IngredientSelection();
            IngredientSelection = constants.GetIngredientSelection().OrderBy(t => t.Name).ToList();


        }
    }
}
