using System.Collections.Generic;
using System.Linq;


namespace MERG_PSI
{
   
     class Filters
    {
        public  List<RealEstate> FilterRealEstateByArea(List<RealEstate> houses, double areaFrom, double areaTo)
        {
            return houses.Where(house => house.Area >= areaFrom && house.Area <= areaTo).ToList();
        }
        public  List<RealEstate> FilterRealEstateByPrice(List<RealEstate> houses, double priceFrom, double priceTo)
        {
            return houses.Where(house => house.Price >= priceFrom && house.Price <= priceTo).ToList();
        }
        public  List<RealEstate> FilterRealEstateByMunicipality(List<RealEstate> houses, string municipality)
        {
            return houses.Where(house => (house.Municipality).ToLower().Contains(municipality.ToLower())).ToList();
        }
        public  List<RealEstate> FilterRealEstateByPricePerSqM(List<RealEstate> houses, double pricePerSqMFrom, double pricePerSqMTo)
        {
            return houses.Where(house => house.PricePerSqM>= pricePerSqMFrom && house.PricePerSqM<= pricePerSqMTo).ToList();
        }
        public List<RealEstate> FilterRealEstateByStreet(List<RealEstate> houses, string street)
        {
            return houses.Where(house => (house.Street).ToLower().Contains(street.ToLower())).ToList();
        }
        public List<RealEstate> FilterRealEstateByNumberOfRooms(List<RealEstate> houses, int numberOfRoomsFrom, int numberOfRoomsTo, bool noInfoNumberOfRooms)
        {
            if (noInfoNumberOfRooms)
            {
                return houses.Where(house => (house.NumberOfRooms >= numberOfRoomsFrom && house.NumberOfRooms <= numberOfRoomsTo) || house.NumberOfRooms == 0).ToList();
            }
            else
            {
                return houses.Where(house => house.NumberOfRooms >= numberOfRoomsFrom && house.NumberOfRooms <= numberOfRoomsTo).ToList();
            }
        }
        public List<RealEstate> FilterRealEstateByBuildYear(List<RealEstate> houses, int buildYearFrom, int buildYearTo, bool noInfoBuildYear)
        {
            if (noInfoBuildYear)
            {
                return houses.Where(house => (house.BuildYear >= buildYearFrom && house.BuildYear <= buildYearTo) || house.BuildYear == 0).ToList();
            }
            else
            {
                return houses.Where(house => house.BuildYear >= buildYearFrom && house.BuildYear <= buildYearTo).ToList();
            }

        }
        public List<RealEstate> FilterByRealEstateWhenNoInfoBuildYear(List<RealEstate> houses)
        {
            return houses.Where(house => house.BuildYear == 0).ToList();
        }
        public List<RealEstate> FilterByRealEstateWhenNoInfoNumberOfRooms(List<RealEstate> houses)
        {
            return houses.Where(house => house.NumberOfRooms == 0).ToList();
        }


    }
}
