using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileApp.FürmichbistdueinfachkeinModel
{
    public class ListOfIngredients
    {
        [JsonProperty("data")]
        public List<Ingredient> Data
        {
            get;
            set;
        }
    }
}
