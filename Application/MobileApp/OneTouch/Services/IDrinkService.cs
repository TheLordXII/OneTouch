using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;

public interface IDrinkService
{
    Task<IEnumerable<Drink>> Refresh();
}