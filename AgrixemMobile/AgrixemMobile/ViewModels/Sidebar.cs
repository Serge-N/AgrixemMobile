using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgrixemMobile.ViewModels
{
    public class Sidebar : INotifyPropertyChanged
    {
        public Sidebar()
        {
            FarmAsync();
        }
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get
            {
                return Settings.Name + " " + Settings.Surname;
            }
        }

        public string FarmName  { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void FarmAsync()
        {
           var g = await App.AgrixemManager.GetFarmAsync();
            FarmName = g.Name;
            OnPropertyChanged("FarmName");
        }
    }
}
