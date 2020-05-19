using System;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface INavigationService
    {
        /*void Configure(string pageKey, Type pageType);
        void GoBack();
        void NavigateTo(string pageKey);*/

        string CurrentPageKey { get; }

        void Configure(string pageKey, Type pageType);
        Task GoBack();
        Task NavigateModalAsync(string pageKey, bool animated = true);
        Task NavigateModalAsync(string pageKey, object parameter, bool animated = true);
        Task NavigateAsync(string pageKey, bool animated = true);
        Task NavigateAsync(string pageKey, object parameter, bool animated = true);
    }

}
