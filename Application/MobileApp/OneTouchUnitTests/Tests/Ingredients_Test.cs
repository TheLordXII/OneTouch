
using System;
using MobileApp.FürmichbistdueinfachkeinModel;
using NUnit.Framework;

namespace OneTouchUnitTests.Tests
{
    [TestFixture]
    public class MyTest
    {
        [Test]
        public void Ingredient_Name()
        {
            var ingredient = new Ingredient { Name = "Wodka" };


            Assert.AreEqual("Wodka", ingredient.Name);
        }

        [Test]
        public void Ingredient_ID()
        {
            var ingredient = new Ingredient { ID = "1" };


            Assert.AreEqual("1", ingredient.ID);
        }

        [Test]
        public void Ingredient_Amount()
        {
            var ingredient = new Ingredient { Amount = "3" };


            Assert.AreEqual("3", ingredient.Amount);
        }
    }
}


