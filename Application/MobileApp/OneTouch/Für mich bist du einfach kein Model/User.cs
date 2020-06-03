using System;
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

        public User()
        {
        }
    }
}
