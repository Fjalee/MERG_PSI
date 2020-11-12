using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebScraper
{
    class DomosplusInsideAdScraper : InsideAdScraper
    {
        private readonly Dictionary<string, string> _buildingInfo = new Dictionary<string, string>();
        private readonly string _link;
        public DomosplusInsideAdScraper(string link)
        {
            _link = link;
        }

        public override void Scrape()
        {
            ScrapeBuildingInfo();
            ScrapeMapLink();

            if (MapLink != "")
            {
                MapCoords = ParseMapLinkToCoords(MapLink);
            }
        }

        public override void ParseBuildingInfoLineLabelFromVal(IElement lineHtml)
        {
            var parsedLabel = "";
            string parsedValue;
            try
            {
                parsedLabel = lineHtml.FirstElementChild.InnerHtml;

                var fullInfoLine = lineHtml.TextContent;
                parsedValue = fullInfoLine.Substring(parsedLabel.Length).Replace("\n", "").Trim();
            }
            catch (NullReferenceException)
            {
                var fullInfoLine = lineHtml.TextContent;
                parsedValue = fullInfoLine.Replace("\n", "").Trim();
            }

            _buildingInfo.Add(parsedLabel, parsedValue);
        }

        public override string ParseMapLinkToCoords(string linkString)
        {
            var link = new Uri(linkString);
            if (link.Segments.Length == 4)
            {
                var location = link.Segments[3];
                if (location != null)
                {
                    return Regex.IsMatch(location, @"^[0-9,.]+$") ? location : "";
                }
                else
                {
                    MyLog.Msg($"maps coords contained not only digits \".\" and \",\" : {_link}\n");
                    return "";
                }
            }
            else
            {
                MyLog.Msg($"maps link had {link.Segments.Length} segements rather than 4: {_link}\n");
            }

            return "";
        }

        public override void DictionaryToProperties(Dictionary<string, string> dictionary)
        {
            var areaIEn = dictionary.Where(x => x.Key == "Buto plotas (kv. m):").Select(x => x.Value);
            var pricePerSqMIEn = dictionary.Where(x => x.Key == "1 kv. m kaina:").Select(x => x.Value);
            var numberOfRoomsIEn = dictionary.Where(x => x.Key == "Kambarių skaičius:").Select(x => x.Value);
            var buildYearParsableIEn = dictionary.Where(x => x.Key == "Statybos metai:").Select(x => x.Value);
            var floorIEn = dictionary.Where(x => x.Key == "Aukštas:").Select(x => x.Value);
            var priceIEN = dictionary.Where(x => x.Key == "\n\t\tKaina\t\t\t").Select(x => x.Value);

            Floor = floorIEn.Count() == 1 ? floorIEn.First() : "";
            Area = areaIEn.Count() == 1 ? areaIEn.First().Substring(0, areaIEn.First().IndexOf(" ")).ParseToDoubleLogIfCant() : 0;
            PricePerSqM = pricePerSqMIEn.Count() == 1 ? ParsePriceToDigitOnlyStr(pricePerSqMIEn).ParseToDoubleLogIfCant() : 0;
            BuildYear = buildYearParsableIEn.Count() == 1 ? ParseBuildYearToInt(buildYearParsableIEn, _link) : 0;
            NumberOfRooms = numberOfRoomsIEn.Count() == 1 ? numberOfRoomsIEn.First().ParseToIntLogIfCant() : 0;
            Price = priceIEN.Count() == 1 ? ParsePriceToDigitOnlyStr(priceIEN).ParseToDoubleLogIfCant() : 0;

            LogIfCountIncorrect(floorIEn, "Floor", _link);
            LogIfCountIncorrect(areaIEn, "Area", _link);
            LogIfCountIncorrect(pricePerSqMIEn, "PricePerSqM", _link);
            LogIfCountIncorrect(buildYearParsableIEn, "BuildYear", _link);
            LogIfCountIncorrect(numberOfRoomsIEn, "NumberOfRooms", _link);
        }

        private void ScrapeBuildingInfo()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var buildingInfoLineHtml = GetBuildingInfoLinesHtml();

            if (buildingInfoLineHtml.Any())
            {
                foreach (var element in buildingInfoLineHtml)
                {
                    ParseBuildingInfoLineLabelFromVal(element);
                }
            }

            DictionaryToProperties(_buildingInfo);
        }

        private void ScrapeMapLink()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var mapLink = GetMapLink();
            MapLink = mapLink.Any() ? mapLink.First() : "";
        }

        private IEnumerable<IElement> GetBuildingInfoLinesHtml()
        {
            var buildingInfoLinesHtml = Document.All
                .Where(x => x.LocalName == "tr")
                .Where(x => x.ParentElement.ParentElement.LocalName == "table")
                .Where(x => x.ParentElement.ParentElement.ClassName == "view-group" || x.ParentElement.ParentElement.ClassName == "view-group price-format");

            return buildingInfoLinesHtml;
        }

        private IEnumerable<string> GetMapLink()
        {
            var mapLink = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => ((IHtmlAnchorElement)x).HostName == "www.google.com")
                .Where(x => x.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ClassList.Contains("maps"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            LogIfCountIncorrect(mapLink, "MapLink", _link);

            return mapLink;
        }

        private string ParsePriceToDigitOnlyStr(IEnumerable<string> priceIEN)
        {
            return Regex.Replace(priceIEN.First().Substring(0, priceIEN.First().IndexOf("€")).ToString(), "[^0-9]", "");
        }
    }
}
