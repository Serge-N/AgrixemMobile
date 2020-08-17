using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgrixemMobile.Services
{
    public interface IRestService
    {
        Task<Cattle> GetCattleAsync(int id);
        Task<List<Locations>> GetLocationsCattleAsync();
    }
}