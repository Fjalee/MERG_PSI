using System;
using System.Collections.Generic;
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
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public double Price { get; set; }
        public string MapLink { get; set; }
        public string Municipality { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }

        public RealEstate(string link, double area, double pricePerSqM, int numberOfRooms, int floor, string mapLink, string municipality, string street, int buildYear)
        {
            Link = link;
            Area = area;
            PricePerSqM = pricePerSqM;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            Price = pricePerSqM* area;
            MapLink = mapLink;
            Municipality = municipality;
            Street = street;
            BuildYear = buildYear;
        }
        override
        public string ToString()
        {
            return $"NT yra {Municipality}, šio namo kaina {Price} €, plotas {Area} m2\n";
        }
    }
}
