using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using Newtonsoft.Json;
using OneTouch;

namespace MobileApp.Services
{
    public class FriendService : IFriendService
    {
        public FriendService()
        {
        }

        private const string urlBase = @"https://onetouchnextgen.tech:5000/api/";
        private HttpClient client = new HttpClient();

        public async Task<IEnumerable<User>> Refresh()
        {
            string url = urlBase + @"getFriends/{0}";
            Debug.WriteLine(url);
            Debug.WriteLine(App.User.Username);
            Debug.WriteLine(string.Format(url, App.User.Username));
            string newUrl = string.Format(url, App.User.Username);
            Uri uri = new Uri(newUrl);
            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfFriends>(json);
            
            return result.Data;
        }
    }
}
