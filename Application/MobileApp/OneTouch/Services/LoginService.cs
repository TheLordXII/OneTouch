using System;
namespace MobileApp.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
        }

        ReturnCode ILoginService.CheckCredentials(string Username, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
