using AngleSharp.Text;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace WebScraper
{
    class RevGeocoding
    {
        private const string _apiKey = "AIzaSyBNcsDmpKTd-qo5XLSkgFZcd1WYh_SvOiw";
        private readonly string _baseUrlRGC = "https://maps.googleapis.com/maps/api/geocode/json?latlng=";
        private readonly string _plusUrl = "&key=" + _apiKey + "&sensor=false";// + "&language=lt";//&region=LT";

        public string CoordsToAdress(double latitude, double longitude, string name)
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.DownloadString(_baseUrlRGC + latitude + ","
                + longitude + _plusUrl);
            var jsonResult = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(json);

            var status = jsonResult.Status;

            if (status == "OK")
            {
                foreach (var j in jsonResult.Results.SelectMany(i => i.Address_components.SelectMany(j => j.Types.Where(k => k == name).Select(k => j))))
                {
                    return j.Short_name;
                }
                return string.Empty;  
            }
            else
            {
                return status;
            }

        }
    }
}