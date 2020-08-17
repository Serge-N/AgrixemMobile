using AgrixemMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgrixemMobile.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        public List<Locations> CattleLocations { get; private set; }
        public Cattle Cow { get; private set; }
        public RestService()
        {
#if DEBUG
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }

        public async Task<Cattle> GetCattleAsync(int id)
        {
            Cow = new Cattle();
            var URL = Constants.CattleRestUrl + id;
            Debug.WriteLine($"\n\n\n\n{URL}\n\n\n\n");

            Uri uri = new Uri(string.Format(URL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                Debug.WriteLine($"\n\n\n\nResponse for cattle request: {response.StatusCode}\n\n\n\n");
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

        public async Task<List<Locations>> GetLocationsCattleAsync()
        {
            //farmId not used yet
            CattleLocations = new List<Locations>();

            Uri uri = new Uri(string.Format(Constants.LocationsRestUrl, string.Empty));
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
    }
}
