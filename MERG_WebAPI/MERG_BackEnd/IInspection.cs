using System;
using System.Collections.Generic;
using System.Text;

namespace MERG_BackEnd
{
    public interface IInspection
    {
        public List<RealEstate> GetFilteredListOFRealEstate(List<RealEstate> listOfRealEstate, FiltersValue filtersValue);
    }
}
