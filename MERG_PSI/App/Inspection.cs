using System.Collections.Generic;

namespace App
{
    class Inspection
    {
        public bool IsFilterValueSelected(string filterValue1, string filterValue2)
        {
            if (filterValue1.Equals("Nuo") || filterValue1.Equals("Iki") || filterValue2.Equals("Nuo") || filterValue2.Equals("Iki"))
            {
                return false;
            }
            return true;
        }

        public List<RealEstate> GetFilteredListOFRealEstate(List<RealEstate> listOfRealEstate, List<string> filtersValue, bool noInfoBuildYear, bool noInfoRoomsNumber)
        {
            var filters = new Filters();
            var filteredList = listOfRealEstate;

            filteredList = IsFilterValueSelected(filtersValue[0], filtersValue[1])
                ? filters.FilterRealEstateByPrice(filteredList, priceFrom: int.Parse(filtersValue[0]), priceTo: int.Parse(filtersValue[1]))
                : filteredList;

            filteredList = IsFilterValueSelected(filtersValue[2], filtersValue[3])
                ? filters.FilterRealEstateByArea(filteredList, areaFrom: int.Parse(filtersValue[2]), areaTo: int.Parse(filtersValue[3]))
                : filteredList;

            filteredList = !string.IsNullOrEmpty(filtersValue[4])
                ? filters.FilterRealEstateByMunicipality(filteredList, municipality: filtersValue[4])
                : filteredList;

            filteredList = !string.IsNullOrEmpty(filtersValue[5])
                ? filters.FilterRealEstateByStreet(filteredList, street: filtersValue[5])
                : filteredList;

            filteredList = IsFilterValueSelected(filtersValue[6], filtersValue[7])
                ? filters.FilterRealEstateByPricePerSqM(filteredList, pricePerSqMFrom: int.Parse(filtersValue[6]), pricePerSqMTo: int.Parse(filtersValue[7]))
                : filteredList;

            filteredList = IsFilterValueSelected(filtersValue[8], filtersValue[9])
                ? filters.FilterRealEstateByBuildYear(filteredList, buildYearFrom: int.Parse(filtersValue[8]), buildYearTo: int.Parse(filtersValue[9]), noInfoBuildYear)
                : noInfoBuildYear ? filters.FilterByRealEstateWhenNoInfoBuildYear(filteredList) : filteredList;

            filteredList = IsFilterValueSelected(filtersValue[10], filtersValue[11])
                ? filters.FilterRealEstateByNumberOfRooms(filteredList, numberOfRoomsFrom: int.Parse(filtersValue[10]), numberOfRoomsTo: int.Parse(filtersValue[11]), noInfoRoomsNumber)
                : noInfoRoomsNumber ? filters.FilterByRealEstateWhenNoInfoNumberOfRooms(filteredList) : filteredList;

            return filteredList;
        }
    }
}