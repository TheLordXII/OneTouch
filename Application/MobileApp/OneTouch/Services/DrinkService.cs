using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneTouch;

namespace MobileApp.Services
{
    public class DrinkService : IDrinkService
    {
        private const string urlBase = @"https://onetouchnextgen.tech:5000/api/";
        private HttpClient client = new HttpClient();

        public DrinkService()
        {
        }

        public async Task<IEnumerable<Drink>> Refresh()
        {
            Uri uri = new Uri(string.Format(urlBase + "drinksLong"));

            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfDrinks>(json);
            return result.Data;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients(string drinkID)
        {
            string url = urlBase + @"ingredientlist/{0}";
            Debug.WriteLine(url);
            Uri uri = new Uri(string.Format(url, drinkID));

            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfIngredients>(json);
            return result.Data;
        }

        public async Task<ReturnCode> orderDrink(string drinkID)
        {
            string urlOrder = urlBase + @"mqtt/queue/{0}";
            Uri uriOrder = new Uri(string.Format(urlOrder, drinkID));

            JObject jObject = new JObject();
            jObject.Add("drinkid", drinkID);
            string contentType = "application/json";
            HttpResponseMessage responseOrder = await client.PutAsync(uriOrder, new StringContent(jObject.ToString(), Encoding.UTF8, contentType));

            if (responseOrder.IsSuccessStatusCode)
            {
                string urlCount = urlBase + @"takedrink/drinkid={0}&user={1}";
                Uri uriCount = new Uri(string.Format(urlCount, drinkID, App.User.Username));
                Debug.WriteLine(uriCount.AbsoluteUri);
                jObject.Add("Username", App.User.Username);

                HttpResponseMessage responseCount = await client.PutAsync(uriCount, new StringContent(jObject.ToString(), Encoding.UTF8, contentType));

                if (responseCount.IsSuccessStatusCode)
                {
                    return ReturnCode.success;
                }
                return ReturnCode.countError;
            }
            return ReturnCode.orderError;

        }
    }
}
