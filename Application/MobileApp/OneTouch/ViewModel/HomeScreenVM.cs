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
    public class HomeScreenVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private User User;

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
                                            object[] para = new object[2];
                                            para[0] = SelectedDrink;
                                            para[1] = User;
                                            await _navigationService.NavigateAsync (Locator.DetailsPage, para);
                                        }));

            }
        }

        /// <summary>
        /// ctor 
        /// </summary>
        public HomeScreenVM(User user, IDrinkService drinkService)
        {
            _drinkSerice = drinkService;
            User = user;
            _navigationService = App.NavigationService;
            Drinks = new ObservableCollection<Drink>();

            Task.Run(() =>Refresh());
        }

        public HomeScreenVM(User user): this(user, new DrinkService())
        {

        }
    }
}
