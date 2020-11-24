
using System.Collections.Generic;
using System.Linq;


namespace MERG_BackEnd
{
   
     class Filters
    {
        public  List<RealEstateModel> FilterRealEstateByArea(List<RealEstateModel> houses, double areaFrom, double areaTo, bool areaFromState,bool areaToState)
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

        public  List<RealEstateModel> FilterRealEstateByPrice(List<RealEstateModel> houses, double priceFrom, double priceTo, bool priceFromState, bool priceToState)
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

        public  List<RealEstateModel> FilterRealEstateByPricePerSqM(List<RealEstateModel> houses, double pricePerSqMFrom, double pricePerSqMTo, bool pricePerSqMFromState, bool pricePerSqMToState)
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

        public List<RealEstateModel> FilterRealEstateByNumberOfRooms(List<RealEstateModel> houses, int numberOfRoomsFrom, int numberOfRoomsTo, bool numberOfRoomsFromState, bool numberOfRoomsToState, bool noNumberOfRoomsInfo)
        {
            if(numberOfRoomsFromState && numberOfRoomsToState && noNumberOfRoomsInfo)
            {
                return houses.Where(house => IsValueBetween(house.NumberOfRooms, numberOfRoomsFrom, numberOfRoomsTo) || house.NumberOfRooms == 0).ToList();
            }
            else if (numberOfRoomsFromState && numberOfRoomsToState)
            {
                return houses.Where(house => IsValueBetween(house.NumberOfRooms, numberOfRoomsFrom, numberOfRoomsTo)).ToList();
            }
            else if (numberOfRoomsFromState && noNumberOfRoomsInfo)
            {
                return houses.Where(house => house.NumberOfRooms >= numberOfRoomsFrom || house.NumberOfRooms == 0).ToList();
            }
            else if (numberOfRoomsToState && noNumberOfRoomsInfo)
            {
                return houses.Where(house => house.NumberOfRooms <= numberOfRoomsTo || house.NumberOfRooms == 0).ToList();
            }
            else if (numberOfRoomsFromState)
            {
                return houses.Where(house => house.NumberOfRooms >= numberOfRoomsFrom).ToList();
            }
            else if (numberOfRoomsToState)
            {
                return houses.Where(house => house.NumberOfRooms <= numberOfRoomsTo)
                    .Where(house => house.NumberOfRooms != 0)
                    .ToList();
            }
            else if (noNumberOfRoomsInfo)
            {
                return houses.Where(house =>  house.NumberOfRooms == 0).ToList();
            }
            return houses;
        }

        public List<RealEstateModel> FilterRealEstateByBuildYear(List<RealEstateModel> houses, int buildYearFrom, int buildYearTo, bool buildYearFromState, bool buildYearToState, bool noBuildYearInfo)
        {
            if (buildYearFromState && buildYearToState && noBuildYearInfo)
            {
                return houses.Where(house => IsValueBetween(house.BuildYear, buildYearFrom, buildYearTo) || house.BuildYear == 0).ToList();
            }
            else if (buildYearFromState && buildYearToState)
            {
                return houses.Where(house => IsValueBetween(house.BuildYear, buildYearFrom, buildYearTo)).ToList();
            }
            else if (buildYearFromState && noBuildYearInfo)
            {
                return houses.Where(house => house.BuildYear >= buildYearFrom || house.BuildYear == 0).ToList();
            }
            else if (buildYearToState && noBuildYearInfo)
            {
                return houses.Where(house => house.BuildYear <= buildYearTo || house.BuildYear == 0).ToList();
            }
            else if (buildYearFromState)
            {
                return houses.Where(house => house.BuildYear >= buildYearFrom).ToList();
            }
            else if (buildYearToState)
            {
                return houses.Where(house => house.BuildYear <= buildYearTo)
                    .Where(house => house.BuildYear != 0)
                    .ToList();
            }
            else if (noBuildYearInfo)
            {
                return houses.Where(house => house.BuildYear == 0).ToList();
            }
            return houses;
        }

        private bool IsValueBetween(double value, double critFrom, double critTo)
        {
            return value >= critFrom && value <= critTo;
        }
    }
}
