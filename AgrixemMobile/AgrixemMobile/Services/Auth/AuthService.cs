using AgrixemMobile.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgrixemMobile.Services.Auth
{
    public class AuthService : IAuthService
    {
        readonly HttpClient client;
        public AuthService()
        {
            client = new HttpClient();
        }
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var login = JsonConvert.SerializeObject(loginModel);

            StringContent content = new StringContent(login, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(Constants.LoginUrl, content);

            LoginResult parsedResult = JsonConvert.DeserializeObject<LoginResult>(result.Content.ReadAsStringAsync().Result);

            if (result.IsSuccessStatusCode)
            {
                /*
                
                //store the key
                await _localStorage.SetItemAsync("authToken", parsedResult.Token);
                //Parse token
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(parsedResult.Token);
                //Tell authorization
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", parsedResult.Token); */
               
            }
                return parsedResult;
            
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

    }
}
