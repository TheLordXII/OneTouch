using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using Newtonsoft.Json;

namespace MobileApp.Services
{
    public class DrinkService : IDrinkService
    {
        private const string urlBase = @"https://onetouchnextgen.tech:5000/api/drinks";

        public DrinkService()
        {
        }

        public async Task<IEnumerable<Drink>> Refresh()
        {
            var client = new HttpClient();

            var uri = new Uri(string.Format(urlBase));

            var json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfDrinks>(json);
            return result.Data;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            var client = new HttpClient();

            var uri = new Uri(string.Format(urlBase));

//andere URL

            var json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfIngredients>(json);
            return result.Data;
        }
    }
}
