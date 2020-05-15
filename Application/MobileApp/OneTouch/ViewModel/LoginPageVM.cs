using System;  
using System.ComponentModel;  
using System.Windows.Input;  
using Xamarin.Forms;
using MobileApp.Services;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using OneTouch;

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

        private ILoginService _loginService;
        public readonly INavigationService _navigationService;
        private IDialogService _dialogService;
        public ReturnCode loginResult;

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

        public ICommand NavigateCommand
        {
            set;
            get;
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
                //NavigateCommand = new RelayCommand(() =>
                //                        {
                //                            _navigationService.NavigateTo(Locator.HomeScreen);
                //                        });
                loginResult = ReturnCode.success;
                await _navigationService.NavigateAsync(Locator.HomeScreen);

            }
            else
            {
                loginResult = ReturnCode.wrongCredentials;
                DisplayInvalidLoginPrompt();
                //await _dialogService.ShowMessage("Invalid username or password.");
                //besser: IDialogService
            }
            
        }

        public LoginPageVM() : this(new LoginService(), new DialogService())
        {

        }

        public LoginPageVM(ILoginService loginService, IDialogService dialogService)
        {
            _loginService = loginService;
            _navigationService = App.NavigationService;
            _dialogService = dialogService;

        }



    }
}