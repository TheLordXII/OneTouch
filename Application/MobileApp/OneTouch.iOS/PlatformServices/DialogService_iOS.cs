﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApp.Services;
using OneTouch.iOS.PlatformServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogService_iOS))]
namespace OneTouch.iOS.PlatformServices
{
    public class DialogService_iOS : IDialogService
    {
        public DialogService_iOS()
        {
        }

        readonly List<UIAlertController> _openDialogs = new List<UIAlertController>();

        public async Task ShowMessage(string title, string message)
        {
            await Task.Run(() => { ShowAlert(title, message, "OK", null, null, false, false); });

        }

        public async Task ShowError(string title,
                                    Exception error,
                                    string buttonText,
                                    Action<bool> closeAction,
                                    bool cancelableOnTouchOutside = false,
                                    bool cancelable = false)
        {
            await Task.Run(() => { ShowAlert(title, error.ToString(), buttonText, null, closeAction, cancelableOnTouchOutside, cancelable); });
        }

        public async Task ShowMessage(string title,
                                      string message,
                                      string buttonText,
                                      Action<bool> closeAction,
                                      bool cancelableOnTouchOutside = false,
                                      bool cancelable = false)
        {
            await Task.Run(() => { ShowAlert(title, message, buttonText, null, closeAction, cancelableOnTouchOutside, cancelable); });
        }

        public async Task ShowMessage(string title,
                                      string message,
                                      string buttonConfirmText,
                                      string buttonCancelText,
                                      Action<bool> closeAction,
                                      bool cancelableOnTouchOutside = false,
                                      bool cancelable = false)
        {
            await Task.Run(() => { ShowAlert(title, message, buttonConfirmText, buttonCancelText, closeAction, cancelableOnTouchOutside, cancelable); });
        }

        internal void ShowAlert(string title,
                                string content,
                                string confirmButtonText = null,
                                string cancelButtonText = null,
                                Action<bool> callback = null,
                                bool cancelableOnTouchOutside = false,
                                bool cancelable = false)
        {
            //all this code needs to be in here because UIKit demands the main UI Thread
            Device.BeginInvokeOnMainThread(() =>
            {
                var dialogAlert = UIAlertController.Create(title, content, UIAlertControllerStyle.Alert);
                var okAction = UIAlertAction.Create(!string.IsNullOrEmpty(confirmButtonText) ? confirmButtonText : "OK", UIAlertActionStyle.Default, _ =>
                {
                    callback?.Invoke(true);
                    _openDialogs.Remove(dialogAlert);
                });
                dialogAlert.AddAction(okAction);
                if (!string.IsNullOrEmpty(cancelButtonText))
                {
                    var cancelAction = UIAlertAction.Create(cancelButtonText, UIAlertActionStyle.Cancel, _ =>
                    {
                        callback?.Invoke(false);
                        _openDialogs.Remove(dialogAlert);
                    });
                    dialogAlert.AddAction(cancelAction);
                }
                _openDialogs.Add(dialogAlert);
                var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                rootController.PresentViewController(dialogAlert, true, null);
            });
        }
    }
}

