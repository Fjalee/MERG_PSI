using AngleSharp.Dom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebScraper
{
    public abstract class InsideAdScraper : Scraper
    {
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public int BuildYear { get; set; }
        public string MapLink { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        protected string Link { get; }
        protected Dictionary<string, string> BuildingInfo { get; } = new Dictionary<string, string>();

        public InsideAdScraper(string link)
        {
            Link = link;
        }

        protected abstract void ParseBuildingInfoLineLabelFromVal(IElement buildingInfoLine);

        protected abstract double[] ParseMapLinkToCoords(string link);

        protected abstract void DictionaryToProperties(Dictionary<string, string> dictionary);

        protected void LogIfCountIncorrect(IEnumerable<string> iEn, string valName, string link)
        {
            if (iEn.Count() != 1 && iEn.Count() != 0)
            {
                MyLog.IEnCountInvalid(link, iEn.Count(), valName);
            }
        }

        protected int ParseBuildYearToInt(IEnumerable<string> buildYearParsableIEn, string link)
        {
            var buildYearString = buildYearParsableIEn.First();
            if (buildYearString.Length >= 4)
            {
                return buildYearString.Substring(0, 4).ParseToIntLogIfCant();
            }
            else
            {
                MyLog.Msg($"Build Year \"{buildYearString}\" Doesn't contain 4 characters\n{link}");
                return 0;
            }
        }

        protected double[] SplitCoordinates(string coords)
        {
            var latAndLong = coords.Split(',');

            if (latAndLong.Length != 2)
            {
                MyLog.Msg($"incorrect coordinates {coords} in {Link}");
                return new double[2] { 0, 0 };
            }

            return new double[2] {
                latAndLong[0].ParseToDoubleLogIfCant(NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo),
                latAndLong[1].ParseToDoubleLogIfCant(NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo)
            };
        }
    }
}
