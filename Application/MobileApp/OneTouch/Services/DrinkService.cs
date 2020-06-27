using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<Drink>> RefreshAll()
        {
            string url = urlBase + "drinksLong";
            Uri uri = new Uri(url);

            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfDrinks>(json);
            return result.Data;
        }

        public async Task<IEnumerable<Drink>> RefreshAvailable()
        {
            string url = urlBase + "availableDrinks";
            Uri uri = new Uri(url);

            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfDrinks>(json);
            return result.Data;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients(string drinkID)
        {
            string url = urlBase + @"ingredientlist/{0}";
           
            Uri uri = new Uri(string.Format(url, drinkID));
            Debug.WriteLine(uri.AbsoluteUri);
            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfIngredients>(json);
            return result.Data;
        }

        public async Task<ReturnCode> orderDrink(string drinkID)
        {
            string urlOrder = urlBase + @"mqtt/queue/{0}";
            Uri uriOrder = new Uri(string.Format(urlOrder, drinkID));
            Debug.WriteLine(uriOrder.AbsoluteUri);
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

        public async Task<ReturnCode> CreateDrink(Drink drink)
        {
            string url = urlBase + @"/newdrink/name=:{0}&description=:{1}&creator=:{2}&name1=:{3}&amount1=:{4}&name2=:{5}&amount2=:{6}&name3=:{7}&amount3=:{8}&name4=:{9}&amount4=:{10}&name5=:{11}&amount5=:{12}&name6=:{13}&amount6=:{14}";

            Uri uriOrder = new Uri(string.Format(url, drink.Name, drink.Description, App.User.Username ,drink.Ingredients[0].Name, drink.Ingredients[0].AmountInt, drink.Ingredients[1].Name, drink.Ingredients[1].AmountInt,drink.Ingredients[2].Name, drink.Ingredients[2].AmountInt,drink.Ingredients[3].Name, drink.Ingredients[3].AmountInt, drink.Ingredients[4].Name, drink.Ingredients[4].AmountInt, drink.Ingredients[5].Name, drink.Ingredients[5].AmountInt));
            Debug.WriteLine(uriOrder.AbsoluteUri);
            JObject jObject = new JObject();
            jObject.Add("User", App.User.Username);
            string contentType = "application/json";
            HttpResponseMessage response = await client.PostAsync(uriOrder, new StringContent(jObject.ToString(), Encoding.UTF8, contentType));

            if (response.IsSuccessStatusCode)
            {
                return ReturnCode.success;
            }
            return ReturnCode.fatalError;
        }

        

        //automatischer ctor ohne argumente
    }
}
