using System;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IDialogService
    {
        Task ShowMessage(string title, string message);

        Task ShowError(string title,
                       Exception error,
                       string buttonText,
                       Action<bool> closeAction,
                       bool cancelableOnTouchOutside = false,
                       bool cancelable = false);

        Task ShowMessage(string title,
                         string message,
                         string buttonText,
                         Action<bool> closeAction,
                         bool cancelableOnTouchOutside = false,
                         bool cancelable = false);

        Task ShowMessage(string title,
                         string message,
                         string buttonConfirmText,
                         string buttonCancelText,
                         Action<bool> closeAction,
                         bool cancelableOnTouchOutside = false,
                         bool cancelable = false);
    }
}
