﻿using AgrixemMobile.Models;
using AgrixemMobile.Views;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AgrixemMobile.ViewModels
{
    public class LoginViewModel  : INotifyPropertyChanged
    {
        public Command LoginCommand { get; }
        LoginModel loginUser;
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            loginUser = new LoginModel();
            loginUser.RememberMe = true;
        }

        private async void OnLoginClicked(object obj)
        {
           
            Wrong = Color.Default;
            OnPropertyChanged("Wrong");
            //make logoin request
            var Results = await App.AgrixemManager.Login(loginUser);
            if (Results.Successful)
            {
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(CattlePage)}");
                SecretPass = string.Empty;
                Email = string.Empty;
                OnPropertyChanged("Email");
                OnPropertyChanged("SecretPass");
            }

            else
            {
                Debug.WriteLine($"Login response is :{Results.Successful}");
                Wrong = Color.Red;
                OnPropertyChanged("Wrong");
            }
            
        }
        public string Email
        {
            get
            {
                return loginUser.Email;
            }
            set
            {
                loginUser.Email = value.Trim().ToLower();
            }
        }
        public string SecretPass
        {
            get
            {
                return loginUser.Password;
            }
            set
            {
                loginUser.Password = value.Trim();
            }
        }
        public Color Wrong { get; private set; }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }
}
