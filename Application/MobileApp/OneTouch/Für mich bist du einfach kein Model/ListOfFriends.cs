using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileApp.FürmichbistdueinfachkeinModel
{
    public class ListOfFriends
    {
        [JsonProperty("data")]
        public List<User> Data
        {
            get;
            set;
        }
    }
}

