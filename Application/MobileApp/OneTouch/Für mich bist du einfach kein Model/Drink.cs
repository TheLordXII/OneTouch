
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

        [JsonProperty("Name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("Description")]
        public string Description
        {
            get;
            set;
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

        [JsonProperty("Ingredients")]
        public ListOfIngredients Ingredients
        {
            get;
            set;
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
