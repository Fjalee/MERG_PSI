using MERG_BackEnd;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin_UI.Services;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        public MapPage(RealEstate realEstate)
        {
            InitializeComponent();

            var customMap = new CustomMap
            {
                MapType = MapType.Street
            };

            var customPin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(realEstate.Latitude, realEstate.Longitude),
                Label = realEstate.Municipality,
                Address = realEstate.Microdistrict + ", " + realEstate.Street,
                PricePerSqM = realEstate.PricePerSqM,
                NumberOfRooms = realEstate.NumberOfRooms,
                BuildYear = realEstate.BuildYear,
                Municipality = realEstate.Municipality,
                Floor = realEstate.Floor,
                Area = realEstate.Area,
                Price = realEstate.Price,
                Image = realEstate.Image,
                Link = realEstate.Link
            };

            customMap.CustomPins = new List<CustomPin> { customPin };
            customMap.Pins.Add(customPin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(realEstate.Latitude, realEstate.Longitude), Distance.FromMiles(1.0)));
            container.Children.Add(customMap);

        }

    }
}
