using System;
using System.ComponentModel;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyCHanged(string propertName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertName));
            }
        }

        private readonly INavigationService _navigationService;

        private User _User;
        public User User
        {
            get { return _User; }
            set
            {
                _User = value;
                RaisePropertyCHanged("User");
            }
        }

        public UserVM()
        {
            _navigationService = App.NavigationService;
            User = App.User;
        }
    }
}
