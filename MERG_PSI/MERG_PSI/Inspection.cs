using System;
using System.Collections.Generic;

namespace MERG_PSI
{
    class Inspection
    {
        public Inspection()
        {

        }

        public Boolean isFilterValueSelected(string filterValue)
        {
            if (filterValue.Equals("Nuo") || filterValue.Equals("Iki"))
            {
                return false;
            }
            return true;
        }

        public List<RealEstate> GetFilteredListOFRealEstate(List<RealEstate> listOfRealEstate, List<String> filtersValue, Boolean noInfoBuildYear, Boolean noInfoRoomsNumber)
        {
            var filters = new Filters();
            var filteredList = listOfRealEstate;

            if (isFilterValueSelected(filtersValue[0]) && isFilterValueSelected(filtersValue[1]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);
                filteredList = filters.FilterRealEstateByPrice(filteredList, priceFrom, priceTo);
            }
            if (isFilterValueSelected(filtersValue[2]) && isFilterValueSelected(filtersValue[3]))
            {
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);
                 filteredList = filters.FilterRealEstateByArea(filteredList, areaFrom, areaTo);

            }
            if (!String.IsNullOrEmpty(filtersValue[4]))
            {
               var  municipality = filtersValue[4];
                filteredList = filters.FilterRealEstateByMunicipality(filteredList, municipality);
            }
            if (!String.IsNullOrEmpty(filtersValue[5]))
            {
               var  street = filtersValue[5];
                filteredList = filters.FilterRealEstateByMunicipality(filteredList, street);
            }
            if (isFilterValueSelected(filtersValue[6]) && isFilterValueSelected(filtersValue[7]))
            {
               var  pricePerSqMFrom = int.Parse(filtersValue[6]);
               var  pricePerSqMTo = int.Parse(filtersValue[7]);
                filteredList = filters.FilterRealEstateByPricePerSqM(filteredList, pricePerSqMFrom,pricePerSqMTo);
            }

            /* ----------------------------------------------------------------------------------*/

            if (isFilterValueSelected(filtersValue[8]) && isFilterValueSelected(filtersValue[9]))
            {
                var buildYearFrom = int.Parse(filtersValue[8]);
                var buildYearTo = int.Parse(filtersValue[9]);
                filteredList = filters.FilterRealEstateByBuildYear(filteredList, buildYearFrom, buildYearTo,noInfoBuildYear);
            }
            else if (noInfoBuildYear)
            {
                filteredList = filters.FilterByRealEstateWhenNoInfoBuildYear(filteredList);
            }

            /* ----------------------------------------------------------------------------------*/
            if (isFilterValueSelected(filtersValue[10]) && isFilterValueSelected(filtersValue[11]))
            {
               var  numberOfRoomsFrom = int.Parse(filtersValue[10]);
               var  numberOfRoomsTo = int.Parse(filtersValue[11]);
                filteredList = filters.FilterRealEstateByNumberOfRooms(filteredList, numberOfRoomsFrom, numberOfRoomsTo, noInfoRoomsNumber);
            }
            else if (noInfoRoomsNumber)
            {
                filteredList = filters.FilterByRealEstateWhenNoInfoNumberOfRooms(filteredList);

            }
            /* ----------------------------------------------------------------------------------*/
            return filteredList;
        }
    }

}
