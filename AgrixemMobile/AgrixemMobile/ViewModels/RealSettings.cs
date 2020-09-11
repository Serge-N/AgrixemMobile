using AgrixemMobile.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgrixemMobile.ViewModels
{
    public class RealSettings : INotifyPropertyChanged
    {
        public RealSettings()
        {
            MyFarm();
        }

        public ObservableCollection<Farms> Farms { get; private set; }

        private async void MyFarm()
        {
            var farms = await App.AgrixemManager.GetAllFarmAsync();
            Farms = new ObservableCollection<Farms>(farms);
            OnPropertyChanged("Farms");
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
