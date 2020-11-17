using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text;

namespace WebScraper
{
    class RevGeocoding
    {
        public string Municipality { get; set; }
        public string Microdistrict { get; set; }
        public string Street { get; set; }
        private const string _apiKey = "AIzaSyBNcsDmpKTd-qo5XLSkgFZcd1WYh_SvOiw";
        private readonly string _baseUrlRGC = "https://maps.googleapis.com/maps/api/geocode/json?latlng=";
        private readonly string _plusUrl = "&key=" + _apiKey + "&sensor=false";
        private readonly double _latitude;
        private readonly double _longitude;

        public RevGeocoding(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
            CoordsToAdress();
        }

        private void CoordsToAdress()
        {
            var jsonResult = JsonResults();
            
            if (jsonResult.Status == "OK")
            {
                Municipality = FindRightAdress(jsonResult, "administrative_area_level_2");
                Microdistrict = FindRightAdress(jsonResult, "locality");
                Street = FindRightAdress(jsonResult, "route");
            }
            else
            {
                Municipality = "";
                Microdistrict = "";
                Street = "";
            }
        }

        private GoogleGeoCodeResponse JsonResults()
        {
            var wc = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            var json = wc.DownloadString(_baseUrlRGC + _latitude + "," + _longitude + _plusUrl);
            return JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(json);
        }

        private string FindRightAdress(GoogleGeoCodeResponse jsonResult, string name)
        {
            var address = jsonResult.Results.SelectMany(i => i.Address_components
                                                            .SelectMany(j => j.Types
                                                                              .Where(k => k == name)
                                                                              .Select(k => j)))
                                         .Select(x => x.Short_name)
                                         .First();



            return address;
        }
    }
}
