using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;

public interface IDrinkService
{
    Task<IEnumerable<Drink>> Refresh();
    Task<IEnumerable<Ingredient>> GetIngredients(string drinkID);
    Task<ReturnCode> orderDrink(string drinkID);
}