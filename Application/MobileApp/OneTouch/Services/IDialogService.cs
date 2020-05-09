using System;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IDialogService
    {
        Task ShowMessage(string message);
    }
}
