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
          //  return String.IsNullOrEmpty(textBox.Text);
        }
        public List<RealEstate> GetFilteredList(List<RealEstate> listOfRealEstate, List<String> filtersValue)
        {
            var filters = new Filters();
            //filter by price, area, municipality and street
            if (isFilterValueSelected(filtersValue[0])
                && isFilterValueSelected(filtersValue[1])
                && isFilterValueSelected(filtersValue[2])
                && isFilterValueSelected(filtersValue[3])
                && !String.IsNullOrEmpty(filtersValue[4])
                && !String.IsNullOrEmpty(filtersValue[5]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);
                var municipality = filtersValue[4];
                var street = filtersValue[5];

                var filteredList1 = filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom, priceTo);
                var filteredList2 = filters.FilterRealEstateByArea(filteredList1, areaFrom, areaTo);
                var filteredList3 = filters.FilterRealEstateByMunicipality(filteredList2, municipality);
                var filteredList = filters.FilterRealEstateByStreet(filteredList3, street);

                return filteredList;
            }
            //filter by price, area, municipality
            else if (isFilterValueSelected(filtersValue[0])
                && isFilterValueSelected(filtersValue[1])
                && isFilterValueSelected(filtersValue[2])
                && isFilterValueSelected(filtersValue[3])
                && !String.IsNullOrEmpty(filtersValue[4]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);
                var municipality = filtersValue[4];

                var filteredList1 = filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom, priceTo);
                var filteredList2 = filters.FilterRealEstateByArea(filteredList1, areaFrom, areaTo);
                var filteredList = filters.FilterRealEstateByMunicipality(filteredList2, municipality);

                return filteredList;
            }
            //filter by price and area
            else if (isFilterValueSelected(filtersValue[0])
                && isFilterValueSelected(filtersValue[1])
                && isFilterValueSelected(filtersValue[2])
                && isFilterValueSelected(filtersValue[3]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);

                var filteredList1 = filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom, priceTo);
                var filteredList = filters.FilterRealEstateByArea(filteredList1, areaFrom, areaTo);

                return filteredList;
            }
            //filter by price, municipality and street
            else if (isFilterValueSelected(filtersValue[0])
               && isFilterValueSelected(filtersValue[1])
               && !String.IsNullOrEmpty(filtersValue[4])
               && !String.IsNullOrEmpty(filtersValue[5]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);
                var municipality = filtersValue[4];
                var street = filtersValue[5];

                var filteredList1 = filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom, priceTo);
                var filteredList2 = filters.FilterRealEstateByMunicipality(filteredList1, municipality);
                var filteredList = filters.FilterRealEstateByStreet(filteredList2, street);
                return filteredList;
            }
            //filter by price and municipality
            else if (isFilterValueSelected(filtersValue[0])
                && isFilterValueSelected(filtersValue[1])
                && !String.IsNullOrEmpty(filtersValue[4]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);
                var municipality = filtersValue[4];

                var filteredList1 = filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom, priceTo);
                var filteredList = filters.FilterRealEstateByMunicipality(filteredList1, municipality);

                return filteredList;
            }
            //filter by area, municipality and street
            else if (isFilterValueSelected(filtersValue[2])
                && isFilterValueSelected(filtersValue[3])
                && !String.IsNullOrEmpty(filtersValue[4])
                && !String.IsNullOrEmpty(filtersValue[5]))
            {
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);
                var municipality = filtersValue[4];
                var street = filtersValue[5];

                var filteredList1 = filters.FilterRealEstateByArea(listOfRealEstate, areaFrom, areaTo);
                var filteredList2 = filters.FilterRealEstateByMunicipality(filteredList1, municipality);
                var filteredList = filters.FilterRealEstateByStreet(filteredList2, street);
                return filteredList;

            }
            //filter by area and municipality
            else if (isFilterValueSelected(filtersValue[2])
                && isFilterValueSelected(filtersValue[3])
                && !String.IsNullOrEmpty(filtersValue[4]))
            {
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);
                var municipality = filtersValue[4];

                var filteredList1 = filters.FilterRealEstateByArea(listOfRealEstate, areaFrom, areaTo);
                var filteredList = filters.FilterRealEstateByMunicipality(filteredList1, municipality);

                return filteredList;

            }
            //filter by price
            else if (isFilterValueSelected(filtersValue[0])
               && isFilterValueSelected(filtersValue[1]))
            {
                var priceFrom = int.Parse(filtersValue[0]);
                var priceTo = int.Parse(filtersValue[1]);

                var filteredList = filters.FilterRealEstateByPrice(listOfRealEstate, priceFrom, priceTo);

                return filteredList;
            }
            //filter by area
            else if (isFilterValueSelected(filtersValue[2])
               && isFilterValueSelected(filtersValue[3]))
            {
                var areaFrom = int.Parse(filtersValue[2]);
                var areaTo = int.Parse(filtersValue[3]);

                var filteredList = filters.FilterRealEstateByArea(listOfRealEstate, areaFrom, areaTo);

                return filteredList;
            }
            //filter by municipality and street
            else if (!String.IsNullOrEmpty(filtersValue[4])
                     && !String.IsNullOrEmpty(filtersValue[5]))
            {
                var municipality = filtersValue[4];
                var street = filtersValue[5];

                var filteredList1 = filters.FilterRealEstateByMunicipality(listOfRealEstate, municipality);
                var filteredList = filters.FilterRealEstateByStreet(filteredList1, street);

                return filteredList;
            }
            //filter by municipality
            else if (!String.IsNullOrEmpty(filtersValue[4]))
            {
                var municipality = filtersValue[4];
                var filteredList = filters.FilterRealEstateByMunicipality(listOfRealEstate, municipality);

                return filteredList;
            }
            //no filters selected
            else
            {
                return listOfRealEstate;
            }
        }
    }
}
