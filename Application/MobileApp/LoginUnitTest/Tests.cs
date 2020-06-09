using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MobileApp.Services;
using MobileApp.ViewModel;
using NUnit.Framework;
using OneTouch;
using OneTouch.View;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace LoginUnitTest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        readonly Platform platform;
        ILoginService log = new TestLoginService();
        TestNavigationService nav = new TestNavigationService();

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

        }

        [Test]
        public void TestNavigation()
        {
            
            var vm = new LoginVM(log);

            nav.NavigateTo(Locator.DrinksView);

            Assert.AreEqual(Locator.DrinksView, nav.CurrentPage);
        }

        [Test]
        public void TestValidLogin()
        {
            var vm = new LoginVM(log)
            {
                Username = "Pepsiboi",
                Password = "lol123"
            };

            vm.LoginCommand.Execute(null);

            Assert.AreEqual(vm.Username, App.User.Username);
        }
    }

    internal class TestNavigationService
    {
        public TestNavigationService()
        {
        }

        public string CurrentPage
        {
            get;
            private set;
        }

        public void GoBack()
        {

        }

        public void NavigateTo(string pageKey)
        {
            CurrentPage = pageKey;
        }
    }

    internal class TestDialogservice: IDialogService
    {
        public TestDialogservice()
        {
        }

        public string _message
        {
            get;
            private set;
        }

        public Task ShowError(string title, Exception error, string buttonText, Action<bool> closeAction, bool cancelableOnTouchOutside = false, bool cancelable = false)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string title, string message)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string title, string message, string buttonText, Action<bool> closeAction, bool cancelableOnTouchOutside = false, bool cancelable = false)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string title, string message, string buttonConfirmText, string buttonCancelText, Action<bool> closeAction, bool cancelableOnTouchOutside = false, bool cancelable = false)
        {
            throw new NotImplementedException();
        }
    }

    internal class TestLoginService : ILoginService
    {
        public TestLoginService()
        {
        }

        public async Task<ReturnCode> CheckCredentials(string Username, string Password)
        {
            if (Username.Equals("Pepsiboi") && Password.Equals("lol123"))
            {
                return ReturnCode.success;
            }
            return ReturnCode.wrongCredentials;
        }
    }
}
