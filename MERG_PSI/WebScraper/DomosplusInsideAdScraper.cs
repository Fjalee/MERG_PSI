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
        public DomosplusInsideAdScraper(string link) : base(link) { }

        public override void Scrape()
        {
            ScrapeBuildingInfo();
            ScrapeMapLink();
            ScrapeImage();

            if (MapLink != "")
            {
                MapCoords = ParseMapLinkToCoords(MapLink);
            }
        }

        protected override void ParseBuildingInfoLineLabelFromVal(IElement lineHtml)
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

            BuildingInfo.Add(parsedLabel, parsedValue);
        }

        protected override string ParseMapLinkToCoords(string linkString)
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
                    MyLog.Msg($"maps coords contained not only digits \".\" and \",\" : {Link}\n");
                    return "";
                }
            }
            else
            {
                MyLog.Msg($"maps link had {link.Segments.Length} segements rather than 4: {Link}\n");
            }

            return "";
        }

        protected override void DictionaryToProperties(Dictionary<string, string> dictionary)
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
            BuildYear = buildYearParsableIEn.Count() == 1 ? ParseBuildYearToInt(buildYearParsableIEn, Link) : 0;
            NumberOfRooms = numberOfRoomsIEn.Count() == 1 ? numberOfRoomsIEn.First().ParseToIntLogIfCant() : 0;
            Price = priceIEN.Count() == 1 ? ParsePriceToDigitOnlyStr(priceIEN).ParseToDoubleLogIfCant() : 0;

            LogIfCountIncorrect(floorIEn, "Floor", Link);
            LogIfCountIncorrect(areaIEn, "Area", Link);
            LogIfCountIncorrect(pricePerSqMIEn, "PricePerSqM", Link);
            LogIfCountIncorrect(buildYearParsableIEn, "BuildYear", Link);
            LogIfCountIncorrect(numberOfRoomsIEn, "NumberOfRooms", Link);
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

            DictionaryToProperties(BuildingInfo);
        }

        private void ScrapeMapLink()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            MapLink = GetMapLink();
        }

        private void ScrapeImage()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }
            Image = GetImage();
        }

        private string GetImage()
        {
            var imageIen = Document.All
                .Where(x => x.LocalName == "img")
                .Where(x => x.ParentElement.LocalName == "td")
                .Where(x => x.ParentElement.ClassList.Contains("center"))
                .Select(x => ((IHtmlImageElement)x).Source);

            LogIfCountIncorrect(imageIen, "AdImage", Link);

            return imageIen.Any() ? imageIen.First() : "";
        }

        private IEnumerable<IElement> GetBuildingInfoLinesHtml()
        {
            var buildingInfoLinesHtml = Document.All
                .Where(x => x.LocalName == "tr")
                .Where(x => x.ParentElement.ParentElement.LocalName == "table")
                .Where(x => x.ParentElement.ParentElement.ClassName == "view-group" || x.ParentElement.ParentElement.ClassName == "view-group price-format");

            return buildingInfoLinesHtml;
        }

        private string GetMapLink()
        {
            var mapLinkIen = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => ((IHtmlAnchorElement)x).HostName == "www.google.com")
                .Where(x => x.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ClassList.Contains("maps"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            LogIfCountIncorrect(mapLinkIen, "MapLink", Link);

            return mapLinkIen.Any() ? mapLinkIen.First() : "";
        }

        private string ParsePriceToDigitOnlyStr(IEnumerable<string> priceIEN)
        {
            return Regex.Replace(priceIEN.First().Substring(0, priceIEN.First().IndexOf("€")).ToString(), "[^0-9]", "");
        }
    }
}
