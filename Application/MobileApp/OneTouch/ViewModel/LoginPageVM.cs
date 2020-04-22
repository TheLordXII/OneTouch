using System;  
using System.ComponentModel;  
using System.Windows.Input;  
using Xamarin.Forms;
using OneTouch.FürmichbistdueinfachkeinModel;

namespace OneTouch.ViewModel
{
    public class LoginPageVM : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplaySuccessfulLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //properties
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand
        {
            protected set;
            get;
        }

        public LoginPageVM()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            switch(DatabaseManager.CheckCredentials(Username,Password))
            {
                case ReturnCode.success:
                    DisplaySuccessfulLoginPrompt();
                    break;
                default:
                    DisplayInvalidLoginPrompt();
                    break;
            }
        }
    }
}