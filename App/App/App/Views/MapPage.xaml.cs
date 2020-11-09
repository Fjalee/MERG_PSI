using App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        readonly RealEstateModel MyValue = new RealEstateModel();
        public MapPage(RealEstateModel realEstate)
        {
            InitializeComponent();
            MyValue = realEstate;
            var position = new Position(MyValue.Latitude, MyValue.Longtitude);
            var mapSpan = new MapSpan(position,0.1,0.1);
            var map = new Map(mapSpan);

            var pin = new Pin
            {
                Position = new Position(MyValue.Latitude, MyValue.Longtitude),
                Label = MyValue.Municipality,
                Address = MyValue.Link

            };
            map.Pins.Add(pin);
            container.Children.Add(map);
        }
    }
}