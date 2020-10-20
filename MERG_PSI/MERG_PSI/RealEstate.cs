using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERG_PSI
{
    class RealEstate
    {
        public string Link { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public double Price { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }   //stringas kolkas tegul buna
        public string Construction { get; set; }
        public string Heating { get; set; }
        public int BuildYear { get; set; }
        public string MapLink { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNm { get; set; }
        public string Coordinates { get; set; }

        public RealEstate(string link, double area, double pricePerSqM, int numberOfRooms, string floor, string construction, string heating, string mapLink, string municipality, string city, string street, string houseNm, string coordinates, int buildYear)
        {
            Link = link;
            Area = area;
            PricePerSqM = pricePerSqM;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            Price = pricePerSqM* area;
            Construction = construction;
            Heating = heating;
            MapLink = mapLink;
            Municipality = municipality;
            City = city;
            Street = street;
            HouseNm = houseNm;
            Coordinates = coordinates;
            BuildYear = buildYear;
        }
        override
        public string ToString()
        {
            return $"NT yra {Municipality}, šio namo kaina {Price} €, plotas {Area} m2\n";
        }
    }
}
