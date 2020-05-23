using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using Newtonsoft.Json;

namespace MobileApp.Services
{
    public class FriendService : IFriendService
    {
        public FriendService()
        {
        }

        private const string urlBase = @"https://onetouchnextgen.tech:5000/api/";
        private HttpClient client = new HttpClient();

        public async Task<IEnumerable<User>> RefreshFriends()
        {
            Uri uri = new Uri(string.Format(urlBase + "getFriends/{0}"));

            string json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfFriends>(json);
            return result.Data;
        }
    }
}
