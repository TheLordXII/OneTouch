using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MobileApp.FürmichbistdueinfachkeinModel
{
    public class Ingredient : INotifyPropertyChanged
    {

        [JsonProperty("")]
        public string ID
        {
            get;
            set;
        }

        private string _Name;
        [JsonProperty("Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyCHanged("Name"); }
        }
    


        [JsonProperty("How_Much")]
        public string Amount
        {
            get;
            set;
        }

        private int _AmountInt;
        public int AmountInt
        {
            get { return _AmountInt; }
            set { _AmountInt = value; RaisePropertyCHanged("AmountInt"); }
        }
    

        public Ingredient()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyCHanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

