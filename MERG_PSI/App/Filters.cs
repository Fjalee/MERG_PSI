using System.Collections.Generic;
using System.Linq;


namespace App
{
   
     class Filters
    {
        public  List<RealEstate> FilterRealEstateByArea(List<RealEstate> houses, double areaFrom, double areaTo, bool areaFromState,bool areaToState)
        {
            if (areaFromState && areaToState)
            {
                return houses.Where(house => IsValueBetween(house.Area, areaFrom, areaTo)).ToList();
            }
            else if (areaFromState)
            {
                return houses.Where(house => house.Area >= areaFrom).ToList();
            }
            else if (areaToState)
            {
                return houses.Where(house => house.Area <= areaTo).ToList();
            }
            return houses;
        }

        public  List<RealEstate> FilterRealEstateByPrice(List<RealEstate> houses, double priceFrom, double priceTo, bool priceFromState, bool priceToState)
        {
           
            if (priceFromState && priceToState)
            {
                return houses.Where(house => IsValueBetween(house.Price, priceFrom, priceTo)).ToList();
            }
            else if (priceFromState)
            {
                return houses.Where(house => house.Price >= priceFrom).ToList();
            }
            else if (priceToState)
            {
                return houses.Where(house => house.Price <= priceTo).ToList();
            }
            return houses;
        }

        public  List<RealEstate> FilterRealEstateByMunicipality(List<RealEstate> houses, string municipality)
        {
            return houses.Where(house => (house.Municipality).ToLower().Contains(municipality.ToLower())).ToList();
        }

        public  List<RealEstate> FilterRealEstateByPricePerSqM(List<RealEstate> houses, double pricePerSqMFrom, double pricePerSqMTo, bool pricePerSqMFromState, bool pricePerSqMToState)
        {
            if(pricePerSqMFromState && pricePerSqMToState)
            {
                return houses.Where(house => IsValueBetween(house.PricePerSqM, pricePerSqMFrom, pricePerSqMTo)).ToList();
            }
            else if (pricePerSqMFromState)
            {
                return houses.Where(house => house.PricePerSqM >= pricePerSqMFrom).ToList();
            }
            else if (pricePerSqMToState)
            {
                return houses.Where(house => house.PricePerSqM <= pricePerSqMTo).ToList();
            }
            return houses;
        }

        public List<RealEstate> FilterRealEstateByStreet(List<RealEstate> houses, string street)
        {
            return houses.Where(house => (house.Street).ToLower().Contains(street.ToLower())).ToList();
        }

        public List<RealEstate> FilterRealEstateByNumberOfRooms(List<RealEstate> houses, int numberOfRoomsFrom, int numberOfRoomsTo, bool numberOfRoomsFromState, bool numberOfRoomsToState)
        {
            if(numberOfRoomsFromState && numberOfRoomsToState)
            {
                return houses.Where(house => IsValueBetween(house.NumberOfRooms, numberOfRoomsFrom, numberOfRoomsTo)).ToList();
            }
            else if (numberOfRoomsFromState)
            {
                return houses.Where(house => house.NumberOfRooms >= numberOfRoomsFrom).ToList();
            }
            else if (numberOfRoomsToState)
            {
                return houses.Where(house => house.NumberOfRooms <= numberOfRoomsTo).ToList();
            }
            return houses;
        }

        public List<RealEstate> FilterRealEstateByBuildYear(List<RealEstate> houses, int buildYearFrom, int buildYearTo, bool noInfoBuildYear, bool buildYearFromState, bool buildYearToState)
        {
            if (noInfoBuildYear)
            {
                return houses.Where(house => IsValueBetween(house.BuildYear, buildYearFrom, buildYearTo) || house.BuildYear == 0).ToList();
            }
            else
            {
                return houses.Where(house => IsValueBetween(house.BuildYear, buildYearFrom, buildYearTo)).ToList();
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

        private bool IsValueBetween(double value, double critFrom, double critTo)
        {
            return value >= critFrom && value <= critTo;
        }
    }
}
