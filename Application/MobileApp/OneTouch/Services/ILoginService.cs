using System;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface ILoginService
    {
        Task<ReturnCode> CheckCredentials(string Username, string Password);
    }
}
