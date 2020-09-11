using AgrixemMobile.Models;
using AgrixemMobile.ViewModels;
using Xamarin.Forms;

namespace AgrixemMobile.Views
{
    public partial class Preferences : ContentPage
    {
        public Preferences()
        {
            InitializeComponent();

            if (Settings.FarmId == "0")
            {
                Boss.IsVisible = true;
                BindingContext = new RealSettings();
            }
            else
            {
                Boss.IsVisible = false;
            }


            if (Settings.CattleTracing)
            {
                KeyC.On = Settings.CattleTracing;
            }

            if (Settings.GoatTracing)
            {
                KeyG.On = Settings.GoatTracing;
            }

           

        }

        private void Goats_OnChanged(object sender, ToggledEventArgs e)
        {
            Settings.GoatTracing = e.Value;
        }
        private void Cattle_OnChanged(object sender, ToggledEventArgs e)
        {
            Settings.CattleTracing = e.Value;
        }

        private void FarmPicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var selectedItem = picker.SelectedItem as Farms;
                Settings.FarmId = selectedItem.ID.ToString();
                Navi();
            }
        }
        private async void Navi() => await Shell.Current.GoToAsync("..");
    }
}