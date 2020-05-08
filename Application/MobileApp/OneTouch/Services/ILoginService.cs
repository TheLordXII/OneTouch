using System;
namespace MobileApp.Services
{
    public interface ILoginService
    {
        ReturnCode CheckCredentials(string Username, string Password);
    }
}
