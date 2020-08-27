using AgrixemMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgrixemMobile.Services
{
    public class RestService : IRestService
    {
        readonly HttpClient client;
        public List<Locations> CattleLocations { get; private set; }
        public List<Locations> GoatsLocations { get; private set; }
        public Cattle Cow { get; private set; }
        public RestService()
        {
            client = new HttpClient();
        }
        public async Task<Cattle> GetCattleAsync(int id)
        {
            Cow = new Cattle();
            var URL = Constants.Cow + id;
            

            Uri uri = new Uri(string.Format(URL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Cow = JsonConvert.DeserializeObject<Cattle>(content);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Cow;
        }
        public async Task<List<Locations>> GetLocationsCattleAsync(int v)
        {
  
            CattleLocations = new List<Locations>();

            var URL = Constants.CattleToday + v;

            Uri uri = new Uri(string.Format(URL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    CattleLocations = JsonConvert.DeserializeObject<List<Locations>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return CattleLocations;
        }
        public async Task<List<Locations>> GetLocationsGoatsAsync(int v)
        {

            GoatsLocations = new List<Locations>();

            var URL = Constants.GoatsToday + v;

            Uri uri = new Uri(string.Format(URL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    GoatsLocations = JsonConvert.DeserializeObject<List<Locations>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return CattleLocations;
        }

    }
}
