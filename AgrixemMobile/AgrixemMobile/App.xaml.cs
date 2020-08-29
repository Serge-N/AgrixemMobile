using Xamarin.Forms;
using AgrixemMobile.Services;
using AgrixemMobile.Views;
using System.Net.Http;
using AgrixemMobile.ViewModels;
using System.Diagnostics;

namespace AgrixemMobile
{
    public partial class App : Application
    {
        public static AgrixemManager AgrixemManager { get; private set; }
        public App()
        {
            InitializeComponent();
            //single http client
           
            AgrixemManager = new AgrixemManager(new RestService(new HttpClient()));

            if (string.IsNullOrEmpty(Settings.ApiToken))
            {
                MainPage = new LoginPage();
            }
                
            else
            {
                MainPage = new AppShell();
            }
                

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
