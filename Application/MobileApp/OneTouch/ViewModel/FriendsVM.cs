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
    public class FriendsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
<<<<<<< Updated upstream
        private User User;
=======

>>>>>>> Stashed changes

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

<<<<<<< Updated upstream
        private IDrinkService _drinkSerice;
        private INavigationService _navigationService;

        public ObservableCollection<Drink> Drinks
=======
        private IFriendService _friendSerice;
        private INavigationService _navigationService;

        public ObservableCollection<User> Friends
>>>>>>> Stashed changes
        {
            get;
            private set;
        }

<<<<<<< Updated upstream
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
=======
        private User _selectedFriend;


        public User SelectedFriend
        {
            get
            {
                return _selectedFriend;
            }
            set
            {
                if (_selectedFriend == value)
                {
                    return;
                }
                _selectedFriend = value;
                RaisePropertyChanged("SelectedFriend");
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                
=======

>>>>>>> Stashed changes
            }
        }

        private async Task Refresh()
        {
<<<<<<< Updated upstream
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
=======
            Friends.Clear();
            var friends = await _friendSerice.Refresh();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        private RelayCommand _showDetailsFriendsCommand;

        public RelayCommand ShowDetailsFriendsCommand
        {
            get
            {
                return _showDetailsFriendsCommand
                ?? (_showDetailsFriendsCommand = new RelayCommand(
                                        async () =>
                                        {
                                            object[] para = new object[2];
                                            para[0] = SelectedFriend;
                                            await _navigationService.NavigateAsync(Locator.FriendsDetails, para);
>>>>>>> Stashed changes
                                        }));

            }
        }

        /// <summary>
        /// ctor 
        /// </summary>
<<<<<<< Updated upstream
        public FriendsVM(User user, IDrinkService drinkService)
        {
            _drinkSerice = drinkService;
            User = user;
            _navigationService = App.NavigationService;
            Drinks = new ObservableCollection<Drink>();

            Task.Run(() =>Refresh());
        }

        public FriendsVM(User user): this(user, new DrinkService())
=======
        public FriendsVM(IFriendService friendService)
        {
            _friendSerice = friendService;
            _navigationService = App.NavigationService;
            Friends = new ObservableCollection<User>();

            Task.Run(() => Refresh());
        }

        public FriendsVM() : this(new FriendService())
>>>>>>> Stashed changes
        {

        }
    }
}
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
