using System;

namespace MERG_BackEnd
{
    public class FiltersValue
    {
        public string Municipality { get; set;  }
        public string Microdistrict { get; set;  }
        public string Street { get; set;  }
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

        public FiltersValue(Tuple<bool, int> priceFrom, Tuple<bool, int> priceTo, Tuple<bool, int> areaFrom, Tuple<bool, int> areaTo, Tuple<bool, int> buildYearFrom, Tuple<bool, int> buildYearTo, Tuple<bool, int> numberOfRoomsFrom, Tuple<bool, int> numberOfRoomsTo, Tuple<bool, int> pricePerSqMFrom, Tuple<bool, int> pricePerSqMTo, bool noBuildYearInfo, bool noNumberOfRoomsInfo, string municipality = "", string microdistrict = "", string street = "")
        {
            Municipality = municipality;
            Microdistrict = microdistrict;
            Street = street;
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

        public override string ToString()
        {
            return $"{Municipality}/{Microdistrict}/{Street}/{PriceFrom.Item1}/{PriceFrom.Item2}/{PriceTo.Item1}/" +
                $"{PriceTo.Item2}/{AreaFrom.Item1}/{AreaFrom.Item2}/{AreaTo.Item1}/{AreaTo.Item2}/" +
                $"{BuildYearFrom.Item1}/{BuildYearFrom.Item2}/{BuildYearTo.Item1}/{BuildYearTo.Item2}/" +
                $"{NumberOfRoomsFrom.Item1}/{NumberOfRoomsFrom.Item2}/{NumberOfRoomsTo.Item1}/" +
                $"{NumberOfRoomsTo.Item2}/{PricePerSqMFrom.Item1}/{PricePerSqMFrom.Item2}/{PricePerSqMTo.Item1}/" +
                $"{PricePerSqMTo.Item2}/{NoBuildYearInfo}/{NoNumberOfRoomsInfo}";
        }
    }
}