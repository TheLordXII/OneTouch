
using System;
using System.Collections.ObjectModel;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.ViewModel;
using NUnit.Framework;
using OneTouch;

namespace OneTouchUnitTests.Tests
{
    [TestFixture]
    public class Friends_VMS_Test
    {
        [Test]
        public void Refresh_Friends_notEmpty()
        {
            var friendsVM = new FriendsVM();
            App.User.Username = "Annoua";

            friendsVM.RefreshCommand.Execute(null);

            Assert.IsNotNull(friendsVM.Friends);
        }

        [Test]
        public void Refresh_AppFriends_notEmpty()
        {
            var friendsVM = new FriendsVM();
            App.User.Username = "Annoua";

            friendsVM.RefreshCommand.Execute(null);

            Assert.IsNull(App.User.Friends);
        }

        [Test]
        public void Refresh_Friends_Friend()
        {
            var friendVM = new FriendsVM();
            App.User.Username = "Annoua";

            friendVM.RefreshCommand.Execute(null);

            Assert.IsInstanceOfType(typeof(ObservableCollection<User>), friendVM.Friends);
        }

        [Test]
        public void Refresh_Friends_Name()
        {
            var friendsVM = new FriendsVM();
            App.User.Username = "Annoua";

            friendsVM.RefreshCommand.Execute(null);

            int index = friendsVM.Friends.Count;
            string name;
            if (index != 0)
            {
                name = friendsVM.Friends[index].Username;
            }
            else
            {
                name = "lol";
            }
            Assert.IsNotNull(name);
        }
    }
}
