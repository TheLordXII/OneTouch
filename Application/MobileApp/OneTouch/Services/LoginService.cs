using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using Newtonsoft.Json;

namespace MobileApp.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
        }

        private const string urlBase = "https://onetouchnextgen.tech:5000/api/user/login/username={0}&password={1}";

        public async Task<ReturnCode> CheckCredentials(string Username, string Password)
        {
            
            var client = new HttpClient();
                
            var uri = new Uri(string.Format(urlBase, Username, Password));

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
    }
}
