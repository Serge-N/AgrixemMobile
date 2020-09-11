using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgrixemMobile.Services
{
    public interface IRestService
    {
        Task<List<string>> FarmImagesAsync();
        Task<List<Locations>> GetLocationsCattleAsync(int v);
        Task<List<Locations>> GetLocationsGoatsAsync(int v);
        Task<LoginResult> Login(LoginModel loginModel);
        Task<List<Farms>> GetAllFarmAsync();
        Task<Farms> GetFarmAsync();
        Task<Cattle> GetCattleAsync(long id);
        void Logout();
    }
}