﻿using App.Models;
using System.Collections.Generic;


namespace App.Services
{
    class Inspection
    {
        public List<RealEstateModel> GetFilteredListOFRealEstate(List<RealEstateModel> listOfRealEstate, FiltersValue filtersValue)
        {
            var filters = new Filters();

            listOfRealEstate = filters.FilterRealEstateByArea(houses: listOfRealEstate, areaFrom: filtersValue.AreaFrom.Item2, areaTo: filtersValue.AreaTo.Item2, areaFromState: filtersValue.AreaFrom.Item1, areaToState: filtersValue.AreaTo.Item1);

            listOfRealEstate = filters.FilterRealEstateByPrice(houses: listOfRealEstate, priceFrom: filtersValue.PriceFrom.Item2, priceTo: filtersValue.PriceTo.Item2, priceFromState: filtersValue.PriceFrom.Item1, priceToState: filtersValue.PriceTo.Item1);

            listOfRealEstate = filters.FilterRealEstateByPricePerSqM(houses: listOfRealEstate, pricePerSqMFrom: filtersValue.PricePerSqMFrom.Item2, pricePerSqMTo: filtersValue.PricePerSqMTo.Item2, pricePerSqMFromState: filtersValue.PricePerSqMFrom.Item1, pricePerSqMToState: filtersValue.PricePerSqMTo.Item1);

            listOfRealEstate = filters.FilterRealEstateByNumberOfRooms(houses: listOfRealEstate, numberOfRoomsFrom: filtersValue.NumberOfRoomsFrom.Item2, numberOfRoomsTo: filtersValue.NumberOfRoomsTo.Item2, numberOfRoomsFromState: filtersValue.NumberOfRoomsFrom.Item1, numberOfRoomsToState: filtersValue.NumberOfRoomsTo.Item1, noNumberOfRoomsInfo: filtersValue.NoNumberOfRoomsInfo);

            listOfRealEstate = filters.FilterRealEstateByBuildYear(houses: listOfRealEstate, buildYearFrom: filtersValue.BuildYearFrom.Item2, buildYearTo: filtersValue.BuildYearTo.Item2, buildYearFromState: filtersValue.BuildYearFrom.Item1, buildYearToState: filtersValue.BuildYearTo.Item1, noBuildYearInfo: filtersValue.NoBuildYearInfo);

            return listOfRealEstate;
        }
    }
}