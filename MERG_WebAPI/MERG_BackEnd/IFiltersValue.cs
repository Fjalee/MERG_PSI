using System;
using System.Collections.Generic;
using System.Text;

namespace MERG_BackEnd
{
    public interface IFiltersValue
    {
        public string Municipality { get; set; }
        public string Microdistrict { get; set; }
        public string Street { get; set; }
        public Tuple<bool, int> PriceFrom { get; set; }
        public Tuple<bool, int> PriceTo { get; set; }
        public Tuple<bool, int> AreaTo { get; set; }
        public Tuple<bool, int> AreaFrom { get; set; }
        public Tuple<bool, int> BuildYearFrom { get; set; }
        public Tuple<bool, int> BuildYearTo { get; set; }
        public Tuple<bool, int> NumberOfRoomsFrom { get; set; }
        public Tuple<bool, int> NumberOfRoomsTo { get; set; }
        public Tuple<bool, int> PricePerSqMFrom { get; set; }
        public Tuple<bool, int> PricePerSqMTo { get; set; }
        public bool NoBuildYearInfo { get; set; }
        public bool NoNumberOfRoomsInfo { get; set; }
    }
}
