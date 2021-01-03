using Common;
using System.Collections.Generic;

namespace MERG_BackEnd
{
    public interface IInspection
    {
        public List<RealEstateModel> GetFilteredListOFRealEstate(List<RealEstateModel> listOfRealEstate, FiltersValue filtersValue);
    }
}
