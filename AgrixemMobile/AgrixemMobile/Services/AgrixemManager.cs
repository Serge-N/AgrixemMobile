using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgrixemMobile.Services
{
    public class AgrixemManager 
    {
        IRestService restService;
   
        public AgrixemManager( IRestService restService) 
        {
            this.restService = restService;
        }
        public Task<Cattle> GetCattleAsync(int id)
        {
            return restService.GetCattleAsync(id);
        }
        public Task<List<Locations>>  GetCattleLocations(int v)
        {
            return restService.GetLocationsCattleAsync(v);
        }
        public Task<List<Locations>> GetGoatsLocations(int v)
        {
            return restService.GetLocationsGoatsAsync(v);
        }
        public Task<LoginResult> Login(LoginModel loginModel) 
        {
            return restService.Login(loginModel);
        }
        public void Logout() 
        {
            restService.Logout();
        }
        public Task<Farms> GetFarmAsync()
        {
            return restService.GetFarmAsync();
        }

    }
}
