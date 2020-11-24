using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MERG_BackEnd
{
    public class Tools
    {
        public Tuple<bool, int> ConvertToInt(string text)
        {
            var succes = int.TryParse(text, out var number);
            if (succes)
            {
                return new Tuple<bool, int>(succes, number);
            }
            return new Tuple<bool, int>(succes, 0);
        }

        public void OpenLinks(double lat, double lng, List<RealEstate> data)
        {
            var links = data.Where(x => x.Latitude == lat && x.Longitude == lng).Select(x => x.Link);

            foreach (var link in links)
            {
                System.Diagnostics.Process.Start(link);
            }
        }
    }
}
