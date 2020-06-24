using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using Newtonsoft.Json;

namespace MobileApp.Services
{
    public class LoginService : ILoginService
    {
        private HttpClient client = new HttpClient();
        private const string urlBase = "https://onetouchnextgen.tech:5000/api/";

        public LoginService()
        {
        }

        public async Task<ReturnCode> CheckCredentials(string Username, string Password)
        {
            string url = urlBase + @"user/login/username={0}&password={1}";

            Uri uri = new Uri(string.Format(url, Username, Password));

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return ReturnCode.success;
            }
            else if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                return ReturnCode.wrongCredentials;
            }
            return ReturnCode.fatalError;
        }

        public async Task<ReturnCode> CreateAccount(string Username, string Password, string Firstname, string Surname, string Birthdate)
        {
            ////put!!!!
            ///
            string url = urlBase + @"newuser/username={0}&password={1}&name={2}&vorname={3}&gebdate={4}";

            Uri uri = new Uri(string.Format(url, Username, Password, Surname, Firstname, Birthdate));
            Debug.WriteLine(uri.AbsoluteUri);

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return ReturnCode.success;
            }
            return ReturnCode.fatalError;
        }

    }
}
