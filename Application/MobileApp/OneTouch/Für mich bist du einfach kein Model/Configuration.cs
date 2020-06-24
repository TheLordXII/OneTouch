using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MobileApp.FürmichbistdueinfachkeinModel
{
    public class Configuration
    {
        [JsonProperty("Pump1")]
        public string IngredientPump1
        {
            get;
            set;
        }

        [JsonProperty("Pump2")]
        public string IngredientPump2
        {
            get;
            set;
        }

        [JsonProperty("Pump3")]
        public string IngredientPump3
        {
            get;
            set;
        }

        [JsonProperty("Pump4")]
        public string IngredientPump4
        {
            get;
            set;
        }

        [JsonProperty("Pump5")]
        public string IngredientPump5
        {
            get;
            set;
        }

        [JsonProperty("Pump6")]
        public string IngredientPump6
        {
            get;
            set;
        }

        public Configuration()
        {
        }
    }
}
