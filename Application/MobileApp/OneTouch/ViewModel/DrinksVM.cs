using System;
using System.ComponentModel;
using MobileApp.Services;
using MobileApp.FürmichbistdueinfachkeinModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class DrinksVM : INotifyPropertyChanged
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

        private IDrinkService _drinkSerice;
        private INavigationService _navigationService;

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
                RaisePropertyChanged("SelectedDrink");
            }
        }

        private bool _isRefreshing = false;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged("IsRefreshing");
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
                                            IsRefreshing = true;
                                            await Refresh();
                                            IsRefreshing = false;
                                        }));
                
            }
        }

        private async Task Refresh()
        {
            Drinks.Clear();
            var drinks = await _drinkSerice.RefreshAll();
            foreach (var drink in drinks)
            {
                Drinks.Add(drink);
            }
        }

        private RelayCommand _showDetailsCommand;

        public RelayCommand ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                ?? (_showDetailsCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await _navigationService.NavigateAsync (Locator.DrinksDetailView, SelectedDrink);
                                        }));

            }
        }

        private RelayCommand _NewDrinkCommand;

        public RelayCommand NewDrinkCommand
        {
            get
            {
                return _NewDrinkCommand
                ?? (_NewDrinkCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await _navigationService.NavigateAsync(Locator.NewDrinkView);
                                        }));

            }
        }

        /// <summary>
        /// ctor 
        /// </summary>
        public DrinksVM(IDrinkService drinkService)
        {
            _drinkSerice = drinkService;
            _navigationService = App.NavigationService;
            Drinks = new ObservableCollection<Drink>();

            Task.Run(() =>Refresh());
        }

        public DrinksVM(): this(new DrinkService())
        {

        }
    }
}
