using System.Net.Http;
using Xamarin.Forms;

namespace AgrixemMobile
{
    public static class Constants
    {
        // Base URL of REST service
        public static string Cow = "https://agrixemapi.azurewebsites.net/api/Cattle/";
        public static string Goat = "https://agrixemapi.azurewebsites.net/api/Goat/";
        public static string CattleToday = "https://agrixemapi.azurewebsites.net/api/Locations/cattle/current/";
        public static string GoatsToday = "https://agrixemapi.azurewebsites.net/api/Locations/goats/current/";
        public static string LoginUrl = "https://agrixemapi.azurewebsites.net/api/Login";
       
    }
}
