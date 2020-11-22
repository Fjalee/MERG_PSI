using CommonLibrary;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace WebScraper
{
    public class RealEstate : RealEstateModel
    {

        [JsonIgnore]
        private readonly double _calculatedPrice;

        [JsonIgnore]
        private readonly double _scraperPrice;

        public RealEstate(string link = "", double area = 0, double pricePerSqM = 0, int numberOfRooms = 0, string floor = "", double scrapedPrice = 0, string mapLink = "", int buildYear = 0, string image = "", double latitude = 0, double longitude = 0)
        {
            Link = link;
            Area = area;
            PricePerSqM = pricePerSqM;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            _scraperPrice = scrapedPrice;
            MapLink = mapLink;
            BuildYear = buildYear;
            Image = image;
            Latitude = latitude;
            Longitude = longitude;

            _calculatedPrice = pricePerSqM * area;
            Price = DeterminePrice();

            var adress = new RevGeocoding(Latitude, Longitude);
            Municipality = adress.Municipality;
            Microdistrict = adress.Microdistrict;
            Street = adress.Street;
        }
        
        override
        public string ToString()
        {
            return $"Link|    {Link}\n" +
                   $"Area|    {Area}\n" +
                   $"PricePerSqM|    {PricePerSqM}\n" +
                   $"NumberOfRooms|    {NumberOfRooms}\n" +
                   $"Floor|    {Floor}\n" +
                   $"_calculatedPrice|    {_calculatedPrice}\n" +
                   $"ScrapedPrice|    {_scraperPrice}\n" +
                   $"Price|    {Price}\n" +
                   $"MapLink|    {MapLink}\n" +
                   $"Municipality|    {Municipality}\n" +
                   $"Street|    {Street}\n" +
                   $"BuildYear|    {BuildYear}\n" +
                   $"Latitude|    {Latitude}\n" +
                   $"Longitude|    {Longitude}\n" +
                   $"\n\n\n";
        }

        public double DeterminePrice()
        {
            if (_calculatedPrice != 0 && _scraperPrice != 0 && IsValuesClose(_calculatedPrice, _scraperPrice, 1000))
            {
                return Math.Round(_scraperPrice / 1000) * 1000;
            }
            else if (_calculatedPrice != 0 && _scraperPrice == 0)
            {
                return Math.Round(_calculatedPrice / 1000) * 1000;
            }
            else if (_calculatedPrice == 0 && _scraperPrice != 0)
            {
                return Math.Round(_scraperPrice / 1000) * 1000;
            }
            else
            {
                MyLog.Msg($"Assigned Price 0 to\n{Link}\n");
                return 0;
            }
        }

        public bool IsValuesClose(double value1, double value2, int roundErr)
        {
            var diff = value1 - value2;
            if ((diff <= roundErr && diff >= 0) || (diff <= 0 && diff >= -roundErr))
            {
                return true;
            }
            else { return false; }
        }
    }
}
