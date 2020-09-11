using AgrixemMobile.ViewModels;
using AgrixemMobile.Views;
using System;
using Xamarin.Forms;

namespace AgrixemMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new Sidebar();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.AgrixemManager.Logout();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}
