
using System;
using MobileApp.FürmichbistdueinfachkeinModel;
using NUnit.Framework;

namespace OneTouchUnitTests.Tests
{
    [TestFixture]
    public class Drink_Test
    {
        [Test]
        public void Drink_Name()
        {
            var drink = new Drink { Name = "Wodka-O" };


            Assert.AreEqual("Wodka-O", drink.Name);
        }

        [Test]
        public void Drink_ID()
        {
            var drink = new Drink { ID="1"};


            Assert.AreEqual("1", drink.ID);
        }

        [Test]
        public void Drink_Desription()
        {
            var drink = new Drink {Description = "Dies ist ein Cocktail"};


            Assert.AreEqual("Dies ist ein Cocktail", drink.Description);
        }

        [Test]
        public void Drink_Creator()
        {
            var drink = new Drink { Creator ="Admin"};


            Assert.AreEqual("Admin", drink.Creator);
        }

        [Test]
        public void Drink_TimesTaken()
        {
            var drink = new Drink { TimesTaken = 2};


            Assert.AreEqual(2, drink.TimesTaken);
        }

    }
}
