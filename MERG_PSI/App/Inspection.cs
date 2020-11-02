using System.Collections.Generic;

namespace App
{
    class Inspection
    {
        public List<RealEstate> GetFilteredListOFRealEstate(List<RealEstate> listOfRealEstate, FiltersValue filtersValue)
        {
            var filters = new Filters();

            listOfRealEstate = filters.FilterRealEstateByArea(houses: listOfRealEstate, areaFrom: filtersValue.AreaFrom.Item2, areaTo: filtersValue.AreaTo.Item2, areaFromState: filtersValue.AreaFrom.Item1, areaToState: filtersValue.AreaTo.Item1);

            listOfRealEstate = filters.FilterRealEstateByPrice(houses: listOfRealEstate, priceFrom: filtersValue.PriceFrom.Item2, priceTo: filtersValue.PriceTo.Item2, priceFromState: filtersValue.PriceFrom.Item1, priceToState: filtersValue.PriceTo.Item1);

            listOfRealEstate = filters.FilterRealEstateByPricePerSqM(houses: listOfRealEstate, pricePerSqMFrom: filtersValue.PricePerSqMFrom.Item2, pricePerSqMTo: filtersValue.PricePerSqMTo.Item2, pricePerSqMFromState: filtersValue.PricePerSqMFrom.Item1, pricePerSqMToState: filtersValue.PricePerSqMTo.Item1);

            return listOfRealEstate;
        }
    }
}