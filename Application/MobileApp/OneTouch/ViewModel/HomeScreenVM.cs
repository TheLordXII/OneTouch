using System;
using System.ComponentModel;
using MobileApp.Services;
using MobileApp.FürmichbistdueinfachkeinModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace MobileApp.ViewModel
{
    public class HomeScreenVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyCHanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private IDrinkService _drinkSerice;

        public ObservableCollection<Drink> Drinks
        {
            get;
            private set;
        }

        private Drink _selectedDrink;


        public Drink SelectedDrink
        {
            get
            {
                return _selectedDrink;
            }
            set
            {
                if (_selectedDrink == value)
                {
                    return;
                }
                _selectedDrink = value;
                RaisePropertyCHanged("SelectedFriend");
            }
        }
        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                ?? (_refreshCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await Refresh();
                                        }));
            }
        }

        private async Task Refresh()
        {
            Drinks.Clear();
            var drinks = await _drinkSerice.Refresh();
            foreach (var drink in drinks)
            {
                Drinks.Add(drink);
            }
        }

        /// <summary>
        /// ctor 
        /// </summary>
        public HomeScreenVM( IDrinkService drinkService)
        {
            _drinkSerice = drinkService;
            Drinks = new ObservableCollection<Drink>();
        }

        public HomeScreenVM(): this(new DrinkService())
        {

        }
    }
}
