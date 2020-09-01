using AgrixemMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using AgrixemMobile.ViewModels;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace AgrixemMobile.Services
{
    public class RestService : IRestService
    {
        readonly HttpClient client;
        public List<Locations> CattleLocations { get; private set; }
        public List<Locations> GoatsLocations { get; private set; }
        public Cattle Cow { get; private set; }
        public RestService(HttpClient client)
        {
            this.client = client;
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
            }
            catch (Exception ex)
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

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var login = JsonConvert.SerializeObject(loginModel);

            StringContent content = new StringContent(login, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(Constants.LoginUrl, content);

            LoginResult parsedResult = JsonConvert.DeserializeObject<LoginResult>(result.Content.ReadAsStringAsync().Result);

            if (result.IsSuccessStatusCode)
            {
                //store the key
                Settings.ApiToken = parsedResult.Token;
                //Parse token
                MarkUserAsAuthenticated(parsedResult.Token);
                //Tell authorization
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", parsedResult.Token);

            }
            return parsedResult;

        }

        public void Logout()
        {
            Settings.ApiToken = string.Empty;
            MarkUserAsLoggedOut();
            client.DefaultRequestHeaders.Authorization = null;
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            
            Settings.FarmId = authenticatedUser.Claims.FirstOrDefault(c => c.Type == "Farm")?.Value;
            Settings.Name = authenticatedUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            Settings.Surname = authenticatedUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;

        }

        public void MarkUserAsLoggedOut()
        {
            Settings.FarmId = string.Empty;
            Settings.Name = string.Empty;
            Settings.Surname = string.Empty;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = System.JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task<Farms> GetFarmAsync()
        {
            var Farm = new Farms();

            var URL = Constants.FarmsUrl + Settings.FarmId;
            Debug.WriteLine($"\n\n\n\n\n\n\n\n\n\nAddress: {URL}\n\n\n\n\n\n\n\n\n\n");

            Uri uri = new Uri(string.Format(URL, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Farm = JsonConvert.DeserializeObject<Farms>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Farm;

        }
    }
}
