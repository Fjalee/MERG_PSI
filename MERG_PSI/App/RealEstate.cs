using System;

namespace App
{
    class RealEstate
    {
        public string Link { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        private readonly double _calculatedPrice;
        public double ScrapedPrice { get; set; }
        public double Price { get; set; }
        public string MapLink { get; set; }
        public string Municipality { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }
        public string MapCoords { get; set; }

        public RealEstate(string link = "", double area = 0, double pricePerSqM = 0, int numberOfRooms = 0, string floor = "", double scrapedPrice = 0, string mapLink = "", string municipality = "", string street = "", int buildYear = 0, string mapCoords = "")
        {
            Link = link;
            Area = area;
            PricePerSqM = pricePerSqM;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            ScrapedPrice = scrapedPrice;
            MapLink = mapLink;
            Municipality = municipality;
            Street = street;
            BuildYear = buildYear;
            MapCoords = mapCoords;

            _calculatedPrice = pricePerSqM * area;
            SetPrice();
        }
        override
        public string ToString()
        {
            return $"\n Kaina: {Price} €\n Nuoroda: {Link}\n Kaina/m²: {PricePerSqM} €/m²\n Plotas: {Area} m²\n Kambariai: {NumberOfRooms}\n";
        }

        public void SetPrice()
        {
            if (_calculatedPrice != 0 && ScrapedPrice != 0 && IsValuesClose(_calculatedPrice, ScrapedPrice, 1000))
            {
                Price = Math.Round(ScrapedPrice / 1000) * 1000;
            }
            else if (_calculatedPrice != 0 && ScrapedPrice == 0)
            {
                Price = Math.Round(_calculatedPrice / 1000) * 1000;
            }
            else if (_calculatedPrice == 0 && ScrapedPrice != 0)
            {
                Price = Math.Round(ScrapedPrice / 1000) * 1000;
            }
        }

        public bool IsValuesClose(double value1, double value2, int roundErr)
        {
            var diff = value1 - value2;
            if ((diff < roundErr && diff > 0) || (diff < 0 && diff > -roundErr))
            {
                return true;
            }
            else { return false; }
        }
    }
}