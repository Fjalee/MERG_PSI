using MERG_BackEnd;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin_UI.Services;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullMapPage : ContentPage
    {
        public FullMapPage(List<RealEstate> realEstate)
        {
            InitializeComponent();

            var customMap = new CustomMap
            {
                MapType = MapType.Street
            };
            
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.1694, 23.8813), Distance.FromMiles(7.0)));
            customMap = AddPinsToMap(realEstate, customMap);
            container.Children.Add(customMap);
        }

        private CustomMap AddPinsToMap(List<RealEstate> realEstate, CustomMap map)
        {
            map.CustomPins = new List<CustomPin> { };
            foreach (var house in realEstate)
            {
                var customPin = new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(house.Latitude, house.Longitude),
                    Label = house.Municipality,
                    Address = house.Microdistrict + ", " + house.Street,
                    PricePerSqM = house.PricePerSqM,
                    NumberOfRooms = house.NumberOfRooms,
                    BuildYear = house.BuildYear,
                    Municipality = house.Municipality,
                    Floor = house.Floor,
                    Area = house.Area,
                    Price = house.Price,
                    Image = house.Image,
                    Link = house.Link
                };

                map.CustomPins.Add(customPin);
                map.Pins.Add(customPin);
            }
            return map;
        }
    }
}
