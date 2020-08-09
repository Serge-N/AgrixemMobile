using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AgrixemMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cattle : ContentPage
    {
        public Cattle()
        {
            InitializeComponent();
            Position position = new Position(-15.3923231, 28.3386322);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.5));
            Mapio.MoveToRegion(mapSpan);

            Pin boardwalkPin = new Pin
            {
                Position = new Position(-15.3923231, 28.3285321),
                Label = "CattleX",
                Type = PinType.Generic
            };
            boardwalkPin.MarkerClicked += async (s, args) =>
            {
                args.HideInfoWindow = true;
                string pinName = ((Pin)s).Label;
                await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
            };

            Pin wharfPin = new Pin
            {
                Position = new Position(-15.3923231, 28.3386322),
                Label = "CattleY",
                Type = PinType.Generic
            };
            wharfPin.InfoWindowClicked += async (s, args) =>
            {
                string pinName = ((Pin)s).Label;
                await DisplayAlert("Info Window Clicked", $"The info window was clicked for {pinName}.", "Ok");
            };
            Mapio.Pins.Add(boardwalkPin);
            Mapio.Pins.Add(wharfPin);

            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 8,
                Geopath =
                {
                    new Position(-15.3923231, 28.3386322),
                    new Position(-15.3923332, 28.3386322),
                    new Position(-15.3923731, 28.3386372),
                    new Position(-15.3923431, 28.3386342),
                    new Position(-15.3923231, 28.3387522),
                    new Position(-15.3925231, 28.3386622),
                    new Position(-15.3923221, 28.3386522),
                    new Position(-15.3923221, 28.3386522),
                    new Position(-15.3924231, 28.3386722),
                    new Position(-15.3923231, 28.3285321),
    }
            };
            Mapio.MapElements.Add(polyline);
        }
    }
}