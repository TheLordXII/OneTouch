using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MobileApp.Services;
using MobileApp.ViewModel;
using NUnit.Framework;
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
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

        }

        //[Test]
        //public void TestNavigation()
        //{
        //    var log = new TestLoginService();
        //    var dia = new TestDialogservice();
        //    var nav = new TestNavigationService();
        //    var vm = new LoginPageVM(log, dia, nav);

        //    nav.NavigateTo(Locator.HomeScreen);
            
        //    Assert.AreEqual(Locator.HomeScreen, nav.CurrentPage);
        //}

        //[Test]
        //public void TestValidLogin()
        //{
        //    var log = new TestLoginService();
        //    var dia = new TestDialogservice();
        //    var nav = new TestNavigationService();
        //    var vm = new LoginPageVM(log, dia, nav)
        //    {
        //        Username = "Pepsiboi",
        //        Password = "lol123"
        //    };

        //    vm.LoginCommand.Execute(null);

        //    Assert.AreEqual(ReturnCode.success, vm.loginResult);
        //}
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

        public Task ShowMessage(string message)
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
