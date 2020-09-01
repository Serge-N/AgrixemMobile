using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgrixemMobile.Services
{
    public interface IRestService
    {
        Task<Cattle> GetCattleAsync(int id);
       
        Task<List<Locations>> GetLocationsCattleAsync(int v);
        Task<List<Locations>> GetLocationsGoatsAsync(int v);
        Task<LoginResult> Login(LoginModel loginModel);
        Task<Farms> GetFarmAsync();
        void Logout();

    }
}