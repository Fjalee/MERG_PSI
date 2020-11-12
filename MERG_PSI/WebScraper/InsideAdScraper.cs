using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    abstract class InsideAdScraper : Scraper
    {
        public override IHtmlDocument Document { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public int BuildYear { get; set; }
        public string MapLink { get; set; }
        public string MapCoords { get; set; }
        public double Price { get; set; }

        public abstract void ParseBuildingInfoLineLabelFromVal(IElement buildingInfoLine);

        public abstract string ParseMapLinkToCoords(string link);

        public abstract void DictionaryToProperties(Dictionary<string, string> dictionary);

        public void LogIfCountIncorrect(IEnumerable<string> iEn, string valName, string link)
        {
            if (iEn.Count() != 1 && iEn.Count() != 0)
            {
                MyLog.IEnCountInvalid(link, iEn.Count(), valName);
            }
        }

        public int ParseBuildYearToInt(IEnumerable<string> buildYearParsableIEn, string link)
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
    }
}
