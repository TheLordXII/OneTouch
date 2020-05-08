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
        private const string urlBase = @"http://h2883569.stratoserver.net:5000/api/drinks";

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
    }
}
