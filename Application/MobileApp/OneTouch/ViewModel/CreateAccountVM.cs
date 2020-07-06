using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MobileApp.Services;
using OneTouch;
using Xamarin.Forms;

namespace MobileApp.ViewModel
{
    public class CreateAccountVM : INotifyPropertyChanged
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

        private string _Firstname;
        public string Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                _Firstname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Firstname"));
            }
        }

        private string _Surname;
        public string Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                _Surname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Surname"));
            }
        }

        private string _Birthdate;
        public string Birthdate
        {
            get
            {
                return _Birthdate;
            }
            set
            {
                _Birthdate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Birthdate"));
            }
        }
        private RelayCommand _CreateAccountCommand;

        public RelayCommand CreateAccountCommand
        {
            get
            {
                return _CreateAccountCommand
                ?? (_CreateAccountCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await CreateAccount();
                                        }));

            }
        }

        private async Task CreateAccount()
        {
            string pattern = "^[0-9]{4}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])$";
            DateTime BirthdateDate;
            if (DateTime.TryParseExact(Birthdate, "yyyy-MM-dd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out BirthdateDate))
            { }
            
            //alle felder ausgefüllt
            if (Username != null
                && Password != null
                && Firstname != null
                && Surname != null
                && Birthdate != null) 
            {
                if (Regex.IsMatch(Birthdate, pattern)) //birthdate als richtiges datum
                {
                    if (DateTime.Compare(BirthdateDate.AddYears(18),DateTime.Today) <= 0) //alter 18
                    {
                        var createTask = _loginService.CreateAccount(Username, Password, Firstname, Surname, Birthdate);

                        ReturnCode statusCode = await createTask;

                        await Task.WhenAll(createTask);
                        if (statusCode == ReturnCode.success)
                        {
                            App.User.Username = Username;
                            await _navigationService.NavigateAsync(Locator.MasterPage);
                        }
                        else
                        {
                            await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occured. Please try again later."));
                        }
                    }
                    else
                    {
                        await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "You have to be at least 18 years old to use this service."));
                    }
                }
                else
                {
                    await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Wrong syntax of birthdate, please try again."));
                }
            }
            else
            {
                await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some information is missing, please fill out all fields."));
            }
            

        }

        public CreateAccountVM(): this (new LoginService())
        {
        }

        public CreateAccountVM(ILoginService loginService)
        {
            _loginService = loginService;
            _navigationService = App.NavigationService;

            //var dialogservice = DependencyService.Get<IDialogService>();
            //SimpleIoc.Default.Register<IDialogService>(() => dialogservice);

        }
    }
}
