using System;  
using System.ComponentModel;  
using System.Windows.Input;  
using Xamarin.Forms;
using MobileApp.Services;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using OneTouch;
using MobileApp.FürmichbistdueinfachkeinModel;
using GalaSoft.MvvmLight.Ioc;

namespace MobileApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyCHanged (string propertName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertName));
            }    
        }

        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;

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


        private RelayCommand _loginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                ?? (_loginCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await login();
                                        }));

            }
        }

        private async Task login()
        {

            ReturnCode statusCode = await _loginService.CheckCredentials(Username,Password);
            if (statusCode == ReturnCode.success)
            {
                App.User.Username = Username;
                await _navigationService.NavigateAsync(Locator.MasterPage);
            }
            else if (statusCode == ReturnCode.wrongCredentials)
            {
                await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Invalid credentials", "You tipped in invalid username or password, please try again."));
            }
            else
            {
                await Task.Run(() =>  SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occured. Please try again later."));
            }
            
        }

        public LoginVM() : this(new LoginService())
        {

        }

        public LoginVM(ILoginService loginService)
        {
            _loginService = loginService;
            _navigationService = App.NavigationService;

            var dialogservice = DependencyService.Get<IDialogService>();
            SimpleIoc.Default.Register<IDialogService>(() => dialogservice);

        }



    }
}