using System.Collections.Generic;
using System.Linq;


namespace MERG_BackEnd
{
   
     public class Filters
    {
        public List<RealEstate> FilterRealEstateByMunicipality(List<RealEstate> houses, string municipality) => 
            !string.IsNullOrEmpty(municipality) ? houses.Where(house => house.Municipality.Contains(municipality)).ToList() : houses;

        public List<RealEstate> FilterRealEstateByMicrodistrict(List<RealEstate> houses, string microdistrict) => 
            !string.IsNullOrEmpty(microdistrict) ? houses.Where(house => house.Microdistrict.Contains(microdistrict)).ToList() : houses;

        public List<RealEstate> FilterRealEstateByStreet(List<RealEstate> houses, string street) => 
            !string.IsNullOrEmpty(street) ? houses.Where(house => house.Street.Contains(street)).ToList() : houses;

        public  List<RealEstate> FilterRealEstateByArea(List<RealEstate> houses, double areaFrom, double areaTo, bool areaFromState,bool areaToState)
        {
            if (areaFromState && areaToState)
            {
                return houses.Where(house => IsValueBetween(house.Area, areaFrom, areaTo)).ToList();
            }
            if (areaFromState)
            {
                return houses.Where(house => house.Area >= areaFrom).ToList();
            }
            if (areaToState)
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
            if (priceFromState)
            {
                return houses.Where(house => house.Price >= priceFrom).ToList();
            }
            if (priceToState)
            {
                return houses.Where(house => house.Price <= priceTo).ToList();
            }
            return houses;
        }

        public  List<RealEstate> FilterRealEstateByPricePerSqM(List<RealEstate> houses, double pricePerSqMFrom, double pricePerSqMTo, bool pricePerSqMFromState, bool pricePerSqMToState)
        {
            if(pricePerSqMFromState && pricePerSqMToState)
            {
                return houses.Where(house => IsValueBetween(house.PricePerSqM, pricePerSqMFrom, pricePerSqMTo)).ToList();
            }
            if (pricePerSqMFromState)
            {
                return houses.Where(house => house.PricePerSqM >= pricePerSqMFrom).ToList();
            }
            if (pricePerSqMToState)
            {
                return houses.Where(house => house.PricePerSqM <= pricePerSqMTo).ToList();
            }
            return houses;
        }

        public List<RealEstate> FilterRealEstateByNumberOfRooms(List<RealEstate> houses, int numberOfRoomsFrom, int numberOfRoomsTo, bool numberOfRoomsFromState, bool numberOfRoomsToState, bool noNumberOfRoomsInfo)
        {
            if(numberOfRoomsFromState && numberOfRoomsToState && noNumberOfRoomsInfo)
            {
                return houses.Where(house => IsValueBetween(house.NumberOfRooms, numberOfRoomsFrom, numberOfRoomsTo) || house.NumberOfRooms == 0).ToList();
            }
            if (numberOfRoomsFromState && numberOfRoomsToState)
            {
                return houses.Where(house => IsValueBetween(house.NumberOfRooms, numberOfRoomsFrom, numberOfRoomsTo)).ToList();
            }
            if (numberOfRoomsFromState && noNumberOfRoomsInfo)
            {
                return houses.Where(house => house.NumberOfRooms >= numberOfRoomsFrom || house.NumberOfRooms == 0).ToList();
            }
            if (numberOfRoomsToState && noNumberOfRoomsInfo)
            {
                return houses.Where(house => house.NumberOfRooms <= numberOfRoomsTo || house.NumberOfRooms == 0).ToList();
            }
            if (numberOfRoomsFromState)
            {
                return houses.Where(house => house.NumberOfRooms >= numberOfRoomsFrom).ToList();
            }
            if (numberOfRoomsToState)
            {
                return houses.Where(house => house.NumberOfRooms <= numberOfRoomsTo)
                    .Where(house => house.NumberOfRooms != 0)
                    .ToList();
            }
            if (noNumberOfRoomsInfo)
            {
                return houses.Where(house =>  house.NumberOfRooms == 0).ToList();
            }
            return houses;
        }

        public List<RealEstate> FilterRealEstateByBuildYear(List<RealEstate> houses, int buildYearFrom, int buildYearTo, bool buildYearFromState, bool buildYearToState, bool noBuildYearInfo)
        {
            if (buildYearFromState && buildYearToState && noBuildYearInfo)
            {
                return houses.Where(house => IsValueBetween(house.BuildYear, buildYearFrom, buildYearTo) || house.BuildYear == 0).ToList();
            }
            if (buildYearFromState && buildYearToState)
            {
                return houses.Where(house => IsValueBetween(house.BuildYear, buildYearFrom, buildYearTo)).ToList();
            }
            if (buildYearFromState && noBuildYearInfo)
            {
                return houses.Where(house => house.BuildYear >= buildYearFrom || house.BuildYear == 0).ToList();
            }
            if (buildYearToState && noBuildYearInfo)
            {
                return houses.Where(house => house.BuildYear <= buildYearTo || house.BuildYear == 0).ToList();
            }
            if (buildYearFromState)
            {
                return houses.Where(house => house.BuildYear >= buildYearFrom).ToList();
            }
            if (buildYearToState)
            {
                return houses.Where(house => house.BuildYear <= buildYearTo)
                    .Where(house => house.BuildYear != 0)
                    .ToList();
            }
            if (noBuildYearInfo)
            {
                return houses.Where(house => house.BuildYear == 0).ToList();
            }
            return houses;
        }

        private bool IsValueBetween(double value, double critFrom, double critTo) => value >= critFrom && value <= critTo;
    }
}