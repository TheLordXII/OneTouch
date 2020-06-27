using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;
using OneTouch;

namespace MobileApp.ViewModel
{
    public class ConfigVM: INotifyPropertyChanged
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

        INavigationService _navigationService;
        IConfigurationService _configurationService;

        private ObservableCollection<Ingredient> _IngredientList;
        public ObservableCollection<Ingredient> IngredientList
        {
            get { return _IngredientList; }
            set
            {
                if (_IngredientList == value)
                {
                    return;
                }
                _IngredientList = value;
                RaisePropertyChanged("IngredientList");
            }
        }

        public List<Ingredient> IngredientSelection
        {
            get;
            set;
        }

        private RelayCommand _SubmitConfigCommand;

        public RelayCommand SubmitConfigCommand
        {
            get
            {
                return _SubmitConfigCommand
                ?? (_SubmitConfigCommand = new RelayCommand(
                                        async () =>
                                        {
                                            await SubmitConfig();
                                        }));

            }
        }

        private async Task SubmitConfig()
        {
            var submitTask = _configurationService.SubmitConfig(IngredientList);

            ReturnCode statusCode = await submitTask;

            await Task.WhenAll(submitTask);
            if (statusCode == ReturnCode.success)
            {
                await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Success", "The config will be updated."));
                await _navigationService.NavigateAsync(Locator.MasterPage);
            }
            else
            {
                await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Some unexpected error occured. Please try again later."));
            }
        }

        private async Task GetConfig()
        {
            Configuration conf = await _configurationService.GetConfig();
            IngredientList.Add(new Ingredient { Name = conf.IngredientPump1 });
            IngredientList.Add(new Ingredient { Name = conf.IngredientPump2 });
            IngredientList.Add(new Ingredient { Name = conf.IngredientPump3 });
            IngredientList.Add(new Ingredient { Name = conf.IngredientPump4 });
            IngredientList.Add(new Ingredient { Name = conf.IngredientPump5 });
            IngredientList.Add(new Ingredient { Name = conf.IngredientPump6 });

            
        }

        public ConfigVM() : this(new DrinkService(), new ConfigurationService())
        {

        }
        public ConfigVM(IDrinkService drinkService, IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _navigationService = App.NavigationService;
            IngredientList = new ObservableCollection<Ingredient>();
            Task.Run(() => GetConfig());

            IngredientSelection constants = new IngredientSelection();
            IngredientSelection = constants.GetIngredientSelection().OrderBy(t => t.Name).ToList();

        }
    }
}
