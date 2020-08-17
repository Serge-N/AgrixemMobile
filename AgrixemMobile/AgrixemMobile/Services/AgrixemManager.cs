using AgrixemMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Task<List<Locations>>  GetCattleLocations()
        {
            return restService.GetLocationsCattleAsync();
        }
    }
}
