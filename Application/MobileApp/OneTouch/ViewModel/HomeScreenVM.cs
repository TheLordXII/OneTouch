using System;
using System.ComponentModel;
using MobileApp.Services;
using MobileApp.FürmichbistdueinfachkeinModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace MobileApp.ViewModel
{
    public class HomeScreenVM : INotifyPropertyChanged
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
            var drinks = await _drinkSerice.Refresh();
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
                                            //TODO: show details page
                                        }));

            }
        }

        /// <summary>
        /// ctor 
        /// </summary>
        public HomeScreenVM( IDrinkService drinkService, INavigationService navigationService)
        {
            _drinkSerice = drinkService;
            _navigationService = navigationService;
            Drinks = new ObservableCollection<Drink>();
            Refresh();
        }

        public HomeScreenVM(): this(new DrinkService(), new NavigationService())
        {

        }
    }
}
