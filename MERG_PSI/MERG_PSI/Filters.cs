
using System.Collections.Generic;
using System.Linq;


namespace MERG_PSI
{
   
     class Filters
    {
        public  List<RealEstate> FilterRealEstateByArea(List<RealEstate> houses, double minArea, double maxArea)
        {
            return houses.Where(house => house.Area >= minArea && house.Area <= maxArea).ToList();
        }
        public  List<RealEstate> FilterRealEstateByPrice(List<RealEstate> houses, double PriceFrom, double PriceTo)
        {
            return houses.Where(house => house.Price >= PriceFrom && house.Price <= PriceTo).ToList();
        }
        public  List<RealEstate> FilterRealEstateByMunicipality(List<RealEstate> houses, string municipality)
        {
            return houses.Where(house => (house.Municipality).ToLower().Contains(municipality.ToLower())).ToList();
        }
        public  List<RealEstate> FilterRealEstateByPricePerSqM(List<RealEstate> houses, double PriceFrom, double PriceTo)
        {
            return houses.Where(house => house.PricePerSqM>= PriceFrom && house.PricePerSqM<= PriceTo).ToList();
        }
        public List<RealEstate> FilterRealEstateByStreet(List<RealEstate> houses, string street)
        {
            return houses.Where(house => (house.Street).ToLower().Contains(street.ToLower())).ToList();
        }

    }
}
