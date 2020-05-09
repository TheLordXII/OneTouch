using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MobileApp.Services
{
    public class DialogService : IDialogService
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplaySuccessfulLoginPrompt;

        public DialogService() 
        {
        }

        public async Task ShowMessage(string message)
        {
            Page page = new Page();
            await page.DisplayAlert("Alert", message, "OK");

        }
    }
}
