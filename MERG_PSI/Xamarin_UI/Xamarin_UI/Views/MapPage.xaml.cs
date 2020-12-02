using MERG_BackEnd;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        public MapPage(RealEstate realEstate)
        {
            InitializeComponent();

            var position = new Position(realEstate.Latitude, realEstate.Longitude);
            var mapSpan = new MapSpan(position, 0.1, 0.1);
            var map = new Xamarin.Forms.Maps.Map(mapSpan);

            var pin = new Pin
            {
                Position = new Position(realEstate.Latitude, realEstate.Longitude),
                Label = realEstate.Municipality,
                Address = $"Kaina: { realEstate.Price} € Kaina / m²: { realEstate.PricePerSqM} €/ m² Plotas: { realEstate.Area}m² Metai: { realEstate.BuildYear} Kambariai: { realEstate.NumberOfRooms} Savivaldybė: { realEstate.Municipality} Mikrorajonas: { realEstate.Microdistrict} Gatvė: { realEstate.Street}"
            };
            pin.InfoWindowClicked += async (sender, e) =>
            {
                await Browser.OpenAsync(realEstate.Link, BrowserLaunchMode.SystemPreferred);
            };
            map.Pins.Add(pin);
            container.Children.Add(map);
        }

    }
}
