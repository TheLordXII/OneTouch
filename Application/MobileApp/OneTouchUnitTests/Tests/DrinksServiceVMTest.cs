
using System;
using NUnit.Framework;
using MobileApp.ViewModel;
using MobileApp.Services;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using System.Collections.ObjectModel;
using OneTouch.View;

namespace OneTouchUnitTests.Tests
{
    [TestFixture]
    public class Drink_ServiceVM_Test
    {
        [Test]
        public void Refresh_Drinks_notEmpty()
        {
            var drinksVM = new DrinksVM();

            drinksVM.RefreshCommand.Execute(null);

            Assert.IsNotNull(drinksVM.Drinks);
        }

        [Test]
        public void Refresh_Drinks_Drink()
        {
            var drinksVM = new DrinksVM();

            drinksVM.RefreshCommand.Execute(null);

            Assert.IsInstanceOfType(typeof(ObservableCollection<Drink>), drinksVM.Drinks);
        }

        [Test]
        public void Refresh_Drinks_Name()
        {
            var drinksVM = new DrinksVM();

            drinksVM.RefreshCommand.Execute(null);
            int index = drinksVM.Drinks.Count;
            string name;
            if (index != 0)
            {
                name = drinksVM.Drinks[index].Name;
            }
            else
            {
                name = "lol";
            }
            Assert.IsNotNull(name);
        }

        [Test]
        public void GetIngredients_notNull()
        {
            var drink = new Drink {ID = "43"};
            var drinksdetailVM = new DrinksDetailVM(drink);

            Assert.IsNotNull(drink.Ingredients);
        }

        [Test]
        public void GetIngredients_Ingredient()
        {
            var drink = new Drink { ID = "43" };
            var drinksdetailVM = new DrinksDetailVM(drink);

            Assert.IsInstanceOfType(typeof(ObservableCollection<Ingredient>), drinksdetailVM.drink.Ingredients);
        }

        [Test]
        public void GetIngredients_Ingredient_notnull()
        {
            var drink = new Drink { ID = "43" };
            var drinksdetailVM = new DrinksDetailVM(drink);
            int index = drink.Ingredients.Count;
            string  name;
            if (index !=0)
            {
                name = drinksdetailVM.drink.Ingredients[index].Name;
            }
            else
            {
                name = "lol";
            }
            Assert.IsNotNull(name);
        }
    }
}
