using Xamarin.Forms;

namespace AgrixemMobile
{
    public static class Constants
    {
        // Base URL of REST service
        public static string CattleRestUrl = Device.RuntimePlatform == Device.Android ? "https://localhost:5001/api/Cattle/" : "https://localhost:44378/api/Cattle/";
        public static string LocationsRestUrl = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001/api/todoitems/{0}" : "https://localhost:44378/api/Locations/";
    }
}
