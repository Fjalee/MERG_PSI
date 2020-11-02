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

        //public List<RealEstate> GetFilteredListOFRealEstate(List<RealEstate> listOfRealEstate, List<string> filtersValue, bool noInfoBuildYear, bool noInfoRoomsNumber)
        //{
        //    var filters = new Filters();

        //    listOfRealEstate = IsFilterValueSelected(filtersValue[0], filtersValue[1])
        //        ? filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom: int.Parse(filtersValue[0]), priceTo: int.Parse(filtersValue[1]))
        //        : listOfRealEstate;

        //    listOfRealEstate = IsFilterValueSelected(filtersValue[2], filtersValue[3])
        //        ? filters.FilterRealEstateByArea(listOfRealEstate, areaFrom: int.Parse(filtersValue[2]), areaTo: int.Parse(filtersValue[3]))
        //        : listOfRealEstate;

        //    listOfRealEstate = !string.IsNullOrEmpty(filtersValue[4])
        //        ? filters.FilterRealEstateByMunicipality(listOfRealEstate, municipality: filtersValue[4])
        //        : listOfRealEstate;

        //    listOfRealEstate = !string.IsNullOrEmpty(filtersValue[5])
        //        ? filters.FilterRealEstateByStreet(listOfRealEstate, street: filtersValue[5])
        //        : listOfRealEstate;

        //    listOfRealEstate = IsFilterValueSelected(filtersValue[6], filtersValue[7])
        //        ? filters.FilterRealEstateByPricePerSqM(listOfRealEstate, pricePerSqMFrom: int.Parse(filtersValue[6]), pricePerSqMTo: int.Parse(filtersValue[7]))
        //        : listOfRealEstate;

        //    listOfRealEstate = IsFilterValueSelected(filtersValue[8], filtersValue[9])
        //        ? filters.FilterRealEstateByBuildYear(listOfRealEstate, buildYearFrom: int.Parse(filtersValue[8]), buildYearTo: int.Parse(filtersValue[9]), noInfoBuildYear)
        //        : noInfoBuildYear ? filters.FilterByRealEstateWhenNoInfoBuildYear(listOfRealEstate) : listOfRealEstate;

        //    listOfRealEstate = IsFilterValueSelected(filtersValue[10], filtersValue[11])
        //        ? filters.FilterRealEstateByNumberOfRooms(listOfRealEstate, numberOfRoomsFrom: int.Parse(filtersValue[10]), numberOfRoomsTo: int.Parse(filtersValue[11]), noInfoRoomsNumber)
        //        : noInfoRoomsNumber ? filters.FilterByRealEstateWhenNoInfoNumberOfRooms(listOfRealEstate) : listOfRealEstate;

        //    return listOfRealEstate;
        //}
        public List<RealEstate> GetFilteredListOFRealEstate(List<RealEstate> listOfRealEstate, FiltersValue filtersValue)
        {
            return new List<RealEstate>();
        }
    }
}