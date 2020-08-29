using System;
using System.Collections.Generic;
using AgrixemMobile.Models;
using AgrixemMobile.ViewModels;
using AgrixemMobile.Views;
using Xamarin.Forms;

namespace AgrixemMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new Sidebar();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.AgrixemManager.Logout();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
     
    }
}
