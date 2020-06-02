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
using System.Diagnostics;

namespace MobileApp.ViewModel
{
    public class FriendsVM : INotifyPropertyChanged
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


        private IFriendService _friendSerice;
        private INavigationService _navigationService;

        public ObservableCollection<User> Friends

        {
            get;
            private set;
        }


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

                                        }));

            }
        }

        public FriendsVM(IFriendService friendService)
        {
            _friendSerice = friendService;
            _navigationService = App.NavigationService;
            Friends = new ObservableCollection<User>();
            Debug.WriteLine(App.User.Username);
            Task.Run(() => Refresh());
        }

        public FriendsVM() : this(new FriendService())
        {

        }
    }
}
