using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Xamarin_UI.Services
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}