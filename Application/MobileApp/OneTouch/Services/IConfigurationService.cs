using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace MobileApp.Services
{
    public interface IConfigurationService
    {
        Task<Configuration> GetConfig();
        Task<ReturnCode> SubmitConfig(ObservableCollection<Ingredient> ingredients);
    }
}
