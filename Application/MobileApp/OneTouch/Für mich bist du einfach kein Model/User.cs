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
