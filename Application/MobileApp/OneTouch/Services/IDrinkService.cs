using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;
using MobileApp.Services;

public interface IDrinkService
{
    Task<IEnumerable<Drink>> RefreshAll();
    Task<IEnumerable<Ingredient>> GetIngredients(string drinkID);
    Task<ReturnCode> orderDrink(string drinkID);
    Task<ReturnCode> CreateDrink(Drink drink);
    Task<ReturnCode> SubmitConfig(ObservableCollection<Ingredient> ingredients);
}