using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileApp.FürmichbistdueinfachkeinModel
{
    public class ListOfDrinks
    {
        [JsonProperty ("data")]
        public List<Drink> Data
        {
            get;
            set;
        }
    }
}
