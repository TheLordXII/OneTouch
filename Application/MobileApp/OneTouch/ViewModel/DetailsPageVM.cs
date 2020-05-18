using System;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace MobileApp.ViewModel
{
    public class DetailsPageVM : ViewModelBase
    {
        private Drink _drink;

        public Drink drink
        {
            get
            {
                return _drink;
            }
            set
            {
                if (_drink == value)
                {
                    return;
                }
                _drink = value;
                RaisePropertyChanged("SelectedDrink");
            }
        }

        //for absenden des Drinks popup mit make sure theres a glass

        public DetailsPageVM(Drink selecedDrink)
        {
            drink = selecedDrink;
            Debug.WriteLine(drink.Name);
        }
    }
}
