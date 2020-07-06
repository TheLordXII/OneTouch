
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
namespace MobileApp.FürmichbistdueinfachkeinModel


{
    public class Drink : INotifyPropertyChanged
    {
        [JsonProperty("DrinkID")]
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

        private string _Description;
        [JsonProperty("Description")]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; RaisePropertyCHanged("Description"); }
        }

        [JsonProperty("Times_Taken")]
        public int TimesTaken
        {
            get;
            set;
        }

        [JsonProperty("Creator")]
        public string Creator
        {
            get;
            set;
        }

        private ObservableCollection<Ingredient> _Ingredients;
        [JsonProperty("Ingredients")]
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _Ingredients; }
            set { _Ingredients = value; RaisePropertyCHanged("Ingredients"); }
        }
    

        public Drink()
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
