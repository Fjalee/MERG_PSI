using System;

namespace App.Services
{
    class FiltersValue
    {
        public Tuple<bool, int> PriceFrom { get; }
        public Tuple<bool, int> PriceTo { get; }
        public Tuple<bool, int> AreaTo { get; }
        public Tuple<bool, int> AreaFrom { get; }
        public Tuple<bool, int> BuildYearFrom { get; }
        public Tuple<bool, int> BuildYearTo { get; }
        public Tuple<bool, int> NumberOfRoomsFrom { get; }
        public Tuple<bool, int> NumberOfRoomsTo { get; }
        public Tuple<bool, int> PricePerSqMFrom { get; }
        public Tuple<bool, int> PricePerSqMTo { get; }
        public bool NoBuildYearInfo { get; }
        public bool NoNumberOfRoomsInfo { get; }

        public FiltersValue(Tuple<bool, int> priceFrom, Tuple<bool, int> priceTo, Tuple<bool, int> areaFrom, Tuple<bool, int> areaTo, Tuple<bool, int> buildYearFrom, Tuple<bool, int> buildYearTo, Tuple<bool, int> numberOfRoomsFrom, Tuple<bool, int> numberOfRoomsTo, Tuple<bool, int> pricePerSqMFrom, Tuple<bool, int> pricePerSqMTo, bool noBuildYearInfo, bool noNumberOfRoomsInfo)
        {
            PriceFrom = priceFrom;
            PriceTo = priceTo;
            AreaFrom = areaFrom;
            AreaTo = areaTo;
            BuildYearFrom = buildYearFrom;
            BuildYearTo = buildYearTo;
            NumberOfRoomsFrom = numberOfRoomsFrom;
            NumberOfRoomsTo = numberOfRoomsTo;
            PricePerSqMFrom = pricePerSqMFrom;
            PricePerSqMTo = pricePerSqMTo;
            NoBuildYearInfo = noBuildYearInfo;
            NoNumberOfRoomsInfo = noNumberOfRoomsInfo;
        }
    }
}
