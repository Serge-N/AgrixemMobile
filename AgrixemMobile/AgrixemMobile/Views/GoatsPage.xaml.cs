
using AgrixemMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AgrixemMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoatsPage : ContentPage
    {
        public GoatsPage()
        {
            InitializeComponent();
            
            BindingContext = new GoatViewModel();
        }
    }
}