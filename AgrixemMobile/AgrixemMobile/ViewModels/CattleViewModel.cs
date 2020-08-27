using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Maps;

namespace AgrixemMobile.ViewModels
{
    public class CattleViewModel : INotifyPropertyChanged
    {
        int farmID;
        ObservableCollection<Locations> locations;
        Dictionary<long, ObservableCollection<Locations>> LocationsForEachAnimal;
        public event PropertyChangedEventHandler PropertyChanged;


        public CattleViewModel()
        {
            //get farmID
            farmID = 1;
            GetLocations();
            locations = null;
            Map = null;
            
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
        async void GetLocations()
        {
            locations = new ObservableCollection<Locations>();
            var loc = await App.AgrixemManager.GetCattleLocations(farmID);
            locations = new ObservableCollection<Locations>(loc);
            loc.Count();
            string message = $"\n\n\n\nLocations: {locations.Count}\n\n\n\n";
            Debug.WriteLine(message);
            Groups();
        }
        public void Groups()
        {
            string message = $"\n\n\n\nLocations: {locations.Count}\n\n\n\n";
            Debug.WriteLine(message);

            //Get unqie IDs
            List<long> AnimalIDs = new List<long>();

            foreach (var id in locations)
            {
                if (!AnimalIDs.Contains(id.AnimalID))
                    AnimalIDs.Add(id.AnimalID);
            }

            message = $"\n\n\n\nNumber of animals: {AnimalIDs.Count}\n\n\n\n";
            Debug.WriteLine(message);
            //Create animal lists
            LocationsForEachAnimal = new Dictionary<long, ObservableCollection<Locations>>();

            foreach (var ID in AnimalIDs)
            {
                var Id = locations.Where(x => x.AnimalID == ID).ToList();
                var IdsObserva = new ObservableCollection<Locations>(Id);
                LocationsForEachAnimal.Add(ID, IdsObserva);
            };

            message = $"\n\n\n\n\nAnimal Dictionaries : {LocationsForEachAnimal.Count}\n\n\n\n\n";
            Debug.WriteLine(message);
            OnPropertyChanged("Locations");
            Locations();
        }
       
        public async System.Threading.Tasks.Task<Cattle> GetCow(int CowID)
        {
            OnPropertyChanged();
            return await App.AgrixemManager.GetCattleAsync(CowID);
        }
        public void Locations()
        {
            if (locations != null)
            {
                ObservableCollection<Locations> LastKnown = new ObservableCollection<Locations>();
                foreach (var ID in LocationsForEachAnimal.Keys)
                {
                    //get that dictionary
                    var myCow = LocationsForEachAnimal.FirstOrDefault(e => e.Key == ID);
                    //get the last time stamp in that dictionary
                    var myCurrentPosition = myCow.Value.OrderByDescending(e => e.Timestamp).FirstOrDefault();
                    LastKnown.Add(myCurrentPosition);
                }
                Map = new Map()
                {
                    IsShowingUser = true
                };

                Map.MapType = MapType.Hybrid;

                foreach(var last in LastKnown)
                {
                    if (LastKnown.IndexOf(last)==0)
                    {
                        Position position = new Position(last.Lat, last.Lon);
                        MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.7));
                        Map.MoveToRegion(mapSpan);
                    }
                    Map.Pins.Add( new Pin 
                    {
                       
                        Position = new Position(last.Lat, last.Lon),
                        Label=$"Cattle Id: {last.ID}",
                        Address = "A",
                        Type = PinType.SearchResult
                    });
                }
              ;
                OnPropertyChanged("Map");

                Map.MapClicked += OnMapClicked;

                Debug.WriteLine($"\n\n\n\nPin numbers : {LastKnown.Count}\n Map pins {Map.Pins.Count}\n\n");

                

            }
            void OnMapClicked(object sender, MapClickedEventArgs e)
            {
                GetLocations();
            }

        }
        public Map Map { get; private set; }
    }
}
