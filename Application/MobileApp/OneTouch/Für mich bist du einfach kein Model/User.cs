using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MobileApp.FürmichbistdueinfachkeinModel
{
    public class User
    {
        [JsonProperty("Benutzername")]
        public string Username
        {
            get;
            set;
        }

        [JsonProperty("Drinks_Taken")]
        public string Drinks_Taken
        {
            get;
            set;
        }

        public ObservableCollection<User> Friends
        {
            get;
            set;
        }

        public User()
        {
        }
    }
}
