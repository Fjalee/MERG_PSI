using MERG_BackEnd;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullMapPage : ContentPage
    {
        public FullMapPage(List<RealEstate> realEstate)
        {
            InitializeComponent();

            var position = new Position(55.1694, 23.8813);
            var mapSpan = new MapSpan(position, 4, 4);
            var map = new Map(mapSpan);

            map = AddPinsToMap(realEstate, map);
            container.Children.Add(map);
        }

        private Map AddPinsToMap(List<RealEstate> realEstate, Map map)
        {
            foreach (var house in realEstate)
            {
                var pin = new Pin
                {
                    Position = new Position(house.Latitude, house.Longitude),
                    Label = house.Municipality,
                    Address = $"Kaina: { house.Price} € Kaina / m²: { house.PricePerSqM} €/ m² Plotas: { house.Area}m² Metai: { house.BuildYear} Kambariai: { house.NumberOfRooms} Savivaldybė: { house.Municipality} Mikrorajonas: { house.Microdistrict} Gatvė: { house.Street}"

                };
                map.Pins.Add(pin);
            }
            return map;
        }
    }
}
