using MERG_BackEnd;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin_UI.services;

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
                Address = realEstate.Microdistrict + " " + realEstate.Street,
                Name = "Xamarin",
                Url = realEstate.Image

            };
            customPin.InfoWindowClicked += async (sender, e) =>
            {
                await Browser.OpenAsync(realEstate.Link, BrowserLaunchMode.SystemPreferred);
            };
            customMap.Pins.Add(customPin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(realEstate.Latitude, realEstate.Longitude), Distance.FromMiles(1.0)));
            container.Children.Add(customMap);

        }

    }
}
