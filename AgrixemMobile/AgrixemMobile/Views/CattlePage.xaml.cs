using AgrixemMobile.Models;
using AgrixemMobile.ViewModels;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AgrixemMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CattlePage : ContentPage
    {
        public CattlePage()
        {
            InitializeComponent();
            
            BindingContext = new CattleViewModel();

        }

    }
}