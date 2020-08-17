using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgrixemMobile.Services;
using AgrixemMobile.Views;

namespace AgrixemMobile
{
    public partial class App : Application
    {
        public static AgrixemManager AgrixemManager { get; private set; }
        public App()
        {
            InitializeComponent();
            AgrixemManager = new AgrixemManager(new RestService());

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
