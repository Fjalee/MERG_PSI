using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MERG_PSI
{
    class Inspection
    {
        public Inspection()
        {

        }

        public Boolean IsTextBoxNotEmpty(TextBox textBox)
        {
            if (textBox.Text.Equals("Nuo") || textBox.Text.Equals("Iki"))
            {
                return false;
            }
            return true;
          //  return String.IsNullOrEmpty(textBox.Text);
        }
        public List<RealEstate> GetFilteredList(List<RealEstate> ListOfRealEstate, List<TextBox> TextBoxes)
        {
            var Filters = new Filters();
            if (IsTextBoxNotEmpty(TextBoxes[0])
                && IsTextBoxNotEmpty(TextBoxes[1])
                && IsTextBoxNotEmpty(TextBoxes[2])
                && IsTextBoxNotEmpty(TextBoxes[3])
                && !String.IsNullOrEmpty(TextBoxes[4].Text))
            {
                var PriceFrom = int.Parse(TextBoxes[0].Text);
                var PriceTo = int.Parse(TextBoxes[1].Text);
                var AreaFrom = int.Parse(TextBoxes[2].Text);
                var AreaTo = int.Parse(TextBoxes[3].Text);
                var Municipality = TextBoxes[4].Text;
                var filteredList = Filters.FilterRealEstateByPrice(ListOfRealEstate, PriceFrom, PriceTo);
                var FinalList = Filters.FilterRealEstateByArea(filteredList, AreaFrom, AreaTo);
                var FinalList2 = Filters.FilterRealEstateByMunicipality(FinalList, Municipality.ToLower());
                return FinalList2;
            }

            else if (IsTextBoxNotEmpty(TextBoxes[0])
                && IsTextBoxNotEmpty(TextBoxes[1])
                && IsTextBoxNotEmpty(TextBoxes[2])
                && IsTextBoxNotEmpty(TextBoxes[3]))
            {
                var PriceFrom = int.Parse(TextBoxes[0].Text);
                var PriceTo = int.Parse(TextBoxes[1].Text);
                var AreaFrom = int.Parse(TextBoxes[2].Text);
                var AreaTo = int.Parse(TextBoxes[3].Text);
                var filteredList = Filters.FilterRealEstateByPrice(ListOfRealEstate, PriceFrom, PriceTo);
                var FinalList = Filters.FilterRealEstateByArea(filteredList, AreaFrom, AreaTo);
                return FinalList;
            }

            else if (IsTextBoxNotEmpty(TextBoxes[0])
                && IsTextBoxNotEmpty(TextBoxes[1])
                && !String.IsNullOrEmpty(TextBoxes[4].Text))
            {
                var PriceFrom = int.Parse(TextBoxes[0].Text);
                var PriceTo = int.Parse(TextBoxes[1].Text);
                var Municipality = TextBoxes[4].Text;
                var FilteredList = Filters.FilterRealEstateByPrice(ListOfRealEstate, PriceFrom, PriceTo);
                var FinalList = Filters.FilterRealEstateByMunicipality(FilteredList, Municipality.ToLower());
                return FinalList;
            }
            else if (IsTextBoxNotEmpty(TextBoxes[2])
                && IsTextBoxNotEmpty(TextBoxes[3])
                && !String.IsNullOrEmpty(TextBoxes[4].Text))
            {
                var AreaFrom = int.Parse(TextBoxes[2].Text);
                var AreaTo = int.Parse(TextBoxes[3].Text);
                var Municipality = TextBoxes[4].Text;
                var FilteredList = Filters.FilterRealEstateByArea(ListOfRealEstate, AreaFrom, AreaTo);
                var FinalList = Filters.FilterRealEstateByMunicipality(FilteredList, Municipality.ToLower());
                return FinalList;

            }
            else if (IsTextBoxNotEmpty(TextBoxes[0])
               && IsTextBoxNotEmpty(TextBoxes[1]))
            {
                var PriceFrom = int.Parse(TextBoxes[0].Text);
                var PriceTo = int.Parse(TextBoxes[1].Text);
                var FilteredList = Filters.FilterRealEstateByPrice(ListOfRealEstate, PriceFrom, PriceTo);
                return FilteredList;
            }
            
            else if (IsTextBoxNotEmpty(TextBoxes[2])
               && IsTextBoxNotEmpty(TextBoxes[3]))
            {
                var AreaFrom = int.Parse(TextBoxes[2].Text);
                var AreaTo = int.Parse(TextBoxes[3].Text);
                var FilteredList = Filters.FilterRealEstateByArea(ListOfRealEstate, AreaFrom, AreaTo);
                return FilteredList;
            }
            else if (!String.IsNullOrEmpty(TextBoxes[4].Text))
            {
                var Municipality = TextBoxes[4].Text;
                var FilteredList = Filters.FilterRealEstateByMunicipality(ListOfRealEstate, Municipality.ToLower());
                return FilteredList;
            }
            else
            {
                return ListOfRealEstate;
            }
        }
    }
}
