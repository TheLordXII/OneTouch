using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using MobileApp.FürmichbistdueinfachkeinModel;
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

        private readonly INavigationService _navigationService;

        private MasterPageItem _selectedPage;

        public MasterPageItem SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                if (_selectedPage == value)
                {
                    return;
                }
                _selectedPage = value;
                RaisePropertyChanged("SelectedPage");
            }
        }

        private string SelectedPageString
        {
            get
            {
                string res;
                switch (_selectedPage.Title)
                {
                    case "Drinks":
                        res = Locator.DrinksView;
                        break;
                    case "Friends":
                        res = Locator.Friends;
                        break;
                    case "About":
                        res = Locator.AboutView;
                        break;
                    case "Account":
                        res = Locator.UserView;
                        break;
                    default:
                        res = Locator.MasterPage;
                        break;
                }
                return res;
            }
        }

        private RelayCommand _showPageCommand;

        public RelayCommand ShowPageCommand
        {
            get
            {
                return _showPageCommand
                ?? (_showPageCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await _navigationService.NavigateAsync(SelectedPageString);
                                        }));

            }
        }

        


        public MasterPageVM()
        {
            _navigationService = App.NavigationService;
        }
    }
}
