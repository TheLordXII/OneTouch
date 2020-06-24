using System;
using System.ComponentModel;
using MobileApp.FürmichbistdueinfachkeinModel;
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

        User user;

        public UserVM()
        {
            user.Username = App.User.Username;
        }
    }
}
