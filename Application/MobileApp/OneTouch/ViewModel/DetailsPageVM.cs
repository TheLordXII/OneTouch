using System;
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

        public DetailsPageVM()
        {
        }
    }
}
