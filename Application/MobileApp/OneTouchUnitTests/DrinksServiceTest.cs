
using System;
using NUnit.Framework;
using MobileApp.ViewModel;
using MobileApp.Services;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace OneTouchUnitTests
{
    [TestFixture]
    public class DrinksServiceTest
    {
        [Test]
        public void Drink_test()
        {
            var drink = new Drink {Name= "Wodka-O"};


            Assert.AreEqual("Wodka-O", drink.Name);
        }

        [Test]
        public void Refresh_Drinks()
        {
            var drinksVM = new DrinksVM();

            drinksVM.RefreshCommand.Execute(null);

            Assert.IsNotNull(drinksVM.Drinks);
        }
    }
}
