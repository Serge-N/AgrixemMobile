using AgrixemMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgrixemMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CattlePage : ContentPage
    {
        CattleViewModel cattleViewModel;
        public CattlePage()
        {
            InitializeComponent();
             cattleViewModel = new CattleViewModel();
           
            
        }

        private void Mapio_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            cattleViewModel.GetCow();
        }
    }
}