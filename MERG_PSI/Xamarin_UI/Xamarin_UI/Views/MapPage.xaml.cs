using MERG_BackEnd;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        readonly RealEstate MyValue = new RealEstate();

        public MapPage(RealEstate realEstate)
        {
            InitializeComponent();
            MyValue = realEstate;
            var position = new Position(MyValue.Latitude, MyValue.Longitude);
            var mapSpan = new MapSpan(position, 0.1, 0.1);
            var map = new Map(mapSpan);

            var pin = new Pin
            {
                Position = new Position(MyValue.Latitude, MyValue.Longitude),
                Label = MyValue.Municipality,
                Address = $"Kaina: { MyValue.Price} € Kaina / m²: { MyValue.PricePerSqM} €/ m² Plotas: { MyValue.Area}m² Metai: { MyValue.BuildYear} Kambariai: { MyValue.NumberOfRooms} Savivaldybė: { MyValue.Municipality} Mikrorajonas: { MyValue.Microdistrict} Gatvė: { MyValue.Street}"

            };
            map.Pins.Add(pin);
            container.Children.Add(map);
        }

    }
}