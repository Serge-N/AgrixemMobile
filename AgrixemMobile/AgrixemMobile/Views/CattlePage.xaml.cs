using AgrixemMobile.ViewModels;
using Xamarin.Forms;
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