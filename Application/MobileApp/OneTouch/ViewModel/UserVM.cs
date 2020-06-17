using System;
using MobileApp.FürmichbistdueinfachkeinModel;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class UserVM
    {
        User user;

        public UserVM()
        {
            user.Username = App.User.Username;
        }
    }
}
