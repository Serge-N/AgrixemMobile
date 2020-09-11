using AgrixemMobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AgrixemMobile.ViewModels
{
    public class CattleViewModel : INotifyPropertyChanged
    {
        private readonly int farmID;
        private ObservableCollection<Locations> locations;
        private Dictionary<long, ObservableCollection<Locations>> LocationsForEachAnimal;
        public event PropertyChangedEventHandler PropertyChanged;


        public CattleViewModel()
        {
            //get farmID
            farmID = 1;
            GetLocations();
            locations = null;
            Map = null;

        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        private async void GetLocations()
        {
            locations = new ObservableCollection<Locations>();
            var loc = await App.AgrixemManager.GetCattleLocations(farmID);
            locations = new ObservableCollection<Locations>(loc);
            Groups();
        }
        public void Groups()
        {
            //Get unqie IDs
            List<long> AnimalIDs = new List<long>();

            foreach (var id in locations)
            {
                if (!AnimalIDs.Contains(id.AnimalID))
                {
                    AnimalIDs.Add(id.AnimalID);
                }
            }

            //Create animal lists
            LocationsForEachAnimal = new Dictionary<long, ObservableCollection<Locations>>();

            foreach (var ID in AnimalIDs)
            {
                var Id = locations.Where(x => x.AnimalID == ID).ToList();
                var IdsObserva = new ObservableCollection<Locations>(Id);
                LocationsForEachAnimal.Add(ID, IdsObserva);
            };

            LocationsAsync();
            OnPropertyChanged("Locations");
        }
        public async System.Threading.Tasks.Task<Cattle> GetCow(int CowID)
        {
            return await App.AgrixemManager.GetCattleAsync(CowID);
        }
        public void LocationsAsync()
        {
            if (locations != null)
            {
                ObservableCollection<Locations> LastKnown = new ObservableCollection<Locations>();

                Map = new Map()
                {
                    IsShowingUser = true,
                    MapType = MapType.Hybrid
                };

                foreach (var ID in LocationsForEachAnimal.Keys)
                {

                    //get the last time stamp in that dictionary
                    var myCurrentPosition = LocationsForEachAnimal
                        .FirstOrDefault(e => e.Key == ID)
                        .Value
                        .OrderByDescending(e => e.Timestamp)
                        .FirstOrDefault();

                    LastKnown.Add(myCurrentPosition);



                    //for all cattle movements
                    if (Settings.CattleTracing)
                    {
                        //for each all sort all of today's movements
                        var SingleCattleLocations = LocationsForEachAnimal
                            .FirstOrDefault(e => e.Key == ID)
                            .Value
                            .OrderBy(e => e.Timestamp);


                        //create maplists
                        Polyline polyline = new Polyline
                        {
                            StrokeColor = Color.Red,
                            StrokeWidth = 10
                        };

                        //create a list of a locations

                        foreach (var location in SingleCattleLocations)
                            polyline.Geopath.Add(new Position(location.Lat, location.Lon));


                        Map.MapElements.Add(polyline);
                        OnPropertyChanged("Map");
                    }

                }


                //single cattle present location
                foreach (var last in LastKnown)
                {
                    if (LastKnown.IndexOf(last) == 0)
                    {
                        Position position = new Position(last.Lat, last.Lon);
                        MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.8));
                        Map.MoveToRegion(mapSpan);
                    }
                    
                    

                    Pin pin = new Pin
                    {
                        Position = new Position(last.Lat, last.Lon),
                        Type = PinType.Generic,
                        Address = $"Status: {last.Lat}",
                        Label = $"Name: {last.Lon}"
                    };


                    Map.Pins.Add(pin);

                    OnPropertyChanged("Map");
                };

                Map.MapClicked += OnMapClicked;

            }

            void OnMapClicked(object sender, MapClickedEventArgs e)
            {
                GetLocations();
            }

        }
        public Map Map { get; private set; }
    }
}
