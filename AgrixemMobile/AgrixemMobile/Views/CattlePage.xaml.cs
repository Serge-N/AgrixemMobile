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
        readonly CattleViewModel cattleViewModel;
        public CattlePage()
        {
            InitializeComponent();
            cattleViewModel  = new CattleViewModel();
            BindingContext = cattleViewModel;
             
            
        }
       
    }
}