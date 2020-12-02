using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Xamarin_UI.services
{
    class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}
