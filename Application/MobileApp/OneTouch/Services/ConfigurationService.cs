using System;
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
    public class ConfigurationService: IConfigurationService
    {
        private const string urlBase = @"https://onetouchnextgen.tech:5000/api/";
        private readonly HttpClient client = new HttpClient();

        public async Task<Configuration> GetConfig()
        {
            string url = urlBase + "machine/config";
            Uri uri = new Uri(url);

            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<Configuration>(json);
            return result;
        }

        public async Task<ReturnCode> SubmitConfig(ObservableCollection<Ingredient> ingredients)
        {
            string url = urlBase + @"config/pump1={0}&pump2={1}&pump3={2}&pump4={3}&pump5={4}&pump6={5}";
            Uri uriOrder = new Uri(string.Format(url, ingredients[0].Name, ingredients[1].Name, ingredients[2].Name, ingredients[3].Name, ingredients[4].Name, ingredients[5].Name));
            Debug.WriteLine(uriOrder.AbsoluteUri);
            JObject jObject = new JObject();
            jObject.Add("User", App.User.Username);
            string contentType = "application/json";
            HttpResponseMessage response = await client.PutAsync(uriOrder, new StringContent(jObject.ToString(), Encoding.UTF8, contentType));

            if (response.IsSuccessStatusCode)
            {
                return ReturnCode.success;
            }
            return ReturnCode.fatalError;
        }

        //machine/config -> holen
    }
}
