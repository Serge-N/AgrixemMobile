﻿using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgrixemMobile.Services
{
    public class AgrixemManager
    {
        private readonly IRestService restService;

        public AgrixemManager(IRestService restService)
        {
            this.restService = restService;
        }
        public Task<Cattle> GetCattleAsync(long id)
        {
            return restService.GetCattleAsync(id);
        }
        public Task<Goat> GetGoatAsync(long id)
        {
            return restService.GetGoatAsync(id);
        }
        public Task<List<Locations>> GetCattleLocations(int v)
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
        public Task<List<Farms>> GetAllFarmAsync()
        {
            return restService.GetAllFarmAsync();
        }
        public Task<List<string>> FarmImages()
        {
            return restService.FarmImagesAsync();
        }

    }
}
