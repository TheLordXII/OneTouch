using System;  
using System.ComponentModel;  
using System.Windows.Input;  
using Xamarin.Forms;
using MobileApp.Services;

namespace MobileApp.ViewModel
{
    public class LoginPageVM : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplaySuccessfulLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyCHanged (string propertName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertName));
            }    
        }

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

        

        public void OnSubmit(ILoginService loginService)
        {
            switch (loginService.CheckCredentials(Username, Password))
            {
                case ReturnCode.success:
                    DisplaySuccessfulLoginPrompt();
                    break;
                default:
                    DisplayInvalidLoginPrompt();
                    break;
            }
        }

        public LoginPageVM(ILoginService loginService)
        {

            //SubmitCommand = new Command(OnSubmit(databaseService)); 
        }

        public LoginPageVM() : this(new LoginService())
        {

        }
    }
}