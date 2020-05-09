using System;
namespace MobileApp.Services
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(string pageKey);
    }
}
