using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using MobileApp.Services;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class MasterPageVM: INotifyPropertyChanged
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

        private INavigationService _navigationService;

        private RelayCommand _showDrinksCommand;

        public RelayCommand ShowDrinksCommand
        {
            get
            {
                return _showDrinksCommand
                ?? (_showDrinksCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await _navigationService.NavigateAsync(Locator.HomeScreen);
                                        }));

            }
        }

        private RelayCommand _showFriendsCommand;

        public RelayCommand ShowFriendsCommand
        {
            get
            {
                return _showFriendsCommand
                ?? (_showFriendsCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await _navigationService.NavigateAsync(Locator.Friends);
                                        }));

            }
        }


        public MasterPageVM()
        {
            _navigationService = App.NavigationService;
        }
    }
}
