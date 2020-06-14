
using System;
using MobileApp.FürmichbistdueinfachkeinModel;
using NUnit.Framework;

namespace OneTouchUnitTests.Tests
{
    [TestFixture]
    public class User_Test
    {
        [Test]
        public void User_Name()
        {
            var user = new User { Username = "Anna" };


            Assert.AreEqual("Anna", user.Username);
        }
    }
}
