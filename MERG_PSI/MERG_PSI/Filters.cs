
using System.Collections.Generic;
using System.Linq;


namespace MERG_PSI
{
   
     class Filters
    {
   //pakeist
        public  List<RealEstate> FilterRealEstateByArea(List<RealEstate> houses, double minArea, double maxArea)
        {
            return houses.Where(house => house.Area >= minArea && house.Area <= maxArea).ToList();
        }
        public  List<RealEstate> FilterRealEstateByPrice(List<RealEstate> Houses, double PriceFrom, double PriceTo)
        {
            return Houses.Where(house => house.Price >= PriceFrom && house.Price <= PriceTo).ToList();
        }
        public  List<RealEstate> FilterRealEstateByMunicipality(List<RealEstate> Houses, string municipality)
        {
            return Houses.Where(house => (house.Municipality).ToLower().Contains(municipality)).ToList();
        }
        public  List<RealEstate> FilterRealEstateByPricePerSqM(List<RealEstate> Houses, double PriceFrom, double PriceTo)
        {
            return Houses.Where(house => house.PricePerSqM>= PriceFrom && house.PricePerSqM<= PriceTo).ToList();
        }

    }
}
