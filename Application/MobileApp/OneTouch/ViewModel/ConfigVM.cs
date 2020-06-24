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

        IDrinkService _drinkService;
        INavigationService _navigationService;

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
            int numIngredients = 0;
            for (int i = 0; i < 6; i++)
            {
                if (IngredientList[i].Name != null)
                {
                    numIngredients++;
                }
            }
            //alle felder ausgefüllt
            if (numIngredients == 6)
            {

                var createTask = _drinkService.SubmitConfig(IngredientList);

                ReturnCode statusCode = await createTask;

                await Task.WhenAll(createTask);
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
            else
            {
                await Task.Run(() => SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("Error", "Please fill out all fields."));
            }
        }

        public ConfigVM() : this(new DrinkService())
        {

        }
        public ConfigVM(IDrinkService drinkService)
        {
            _drinkService = drinkService;
            _navigationService = App.NavigationService;
            IngredientList = new ObservableCollection<Ingredient>();
            IngredientList.Add(new Ingredient());
            IngredientList.Add(new Ingredient());
            IngredientList.Add(new Ingredient());
            IngredientList.Add(new Ingredient());
            IngredientList.Add(new Ingredient());
            IngredientList.Add(new Ingredient());

            IngredientSelection constants = new IngredientSelection();
            IngredientSelection = constants.GetIngredientSelection().OrderBy(t => t.Name).ToList();

        }
    }
}
