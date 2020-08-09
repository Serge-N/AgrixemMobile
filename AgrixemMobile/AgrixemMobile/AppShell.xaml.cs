﻿using System;
using System.Collections.Generic;
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
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
