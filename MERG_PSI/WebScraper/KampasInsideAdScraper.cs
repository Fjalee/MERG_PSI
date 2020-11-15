using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebScraper
{
    class KampasInsideAdScraper : InsideAdScraper
    {
        public KampasInsideAdScraper(string link) : base(link) { }

        public override void Scrape()
        {
            ScrapeBuildingInfo();
            ScrapePrice();
            ScrapeMapLink();
            ScrapeImage();

            if (MapLink != "")
            {
                MapCoords = ParseMapLinkToCoords(MapLink);
            }
        }

        protected override void ParseBuildingInfoLineLabelFromVal(IElement lineHtml)
        {
            var parsedValue = "";
            string parsedLabel;

            try
            {
                parsedValue = lineHtml.FirstElementChild.InnerHtml;

                var fullInfoLine = lineHtml.TextContent;
                parsedLabel = fullInfoLine.Substring(0, fullInfoLine.IndexOf(parsedValue)).Replace("\n", "").Trim();
            }
            catch (NullReferenceException)
            {
                var fullInfoLine = lineHtml.TextContent;
                parsedLabel = fullInfoLine.Replace("\n", "").Trim();
            }

            BuildingInfo.Add(parsedLabel, parsedValue);
        }

        protected override string ParseMapLinkToCoords(string linkString)
        {
            var link = new Uri(linkString);
            var location = HttpUtility.ParseQueryString(link.Query).Get("q");

            return Regex.IsMatch(location, @"^[0-9,.]+$") ? location : "";
        }

        protected override void DictionaryToProperties(Dictionary<string, string> dictionary)
        {
            var areaIEn = dictionary.Where(x => x.Key == "Plotas m²:").Select(x => x.Value);
            var pricePerSqMIEn = dictionary.Where(x => x.Key == "€/m²:").Select(x => x.Value);
            var numberOfRoomsIEn = dictionary.Where(x => x.Key == "Kambariai:").Select(x => x.Value);
            var buildYearParsableIEn = dictionary.Where(x => x.Key == "Statybų metai:").Select(x => x.Value);
            var floorIEn = dictionary.Where(x => x.Key == "Aukštas:").Select(x => x.Value);

            Floor = floorIEn.Count() == 1 ? floorIEn.First() : "";
            Area = areaIEn.Count() == 1 ? areaIEn.First().ParseToDoubleLogIfCant() : 0;
            PricePerSqM = pricePerSqMIEn.Count() == 1 ? pricePerSqMIEn.First().ParseToDoubleLogIfCant() : 0;
            BuildYear = buildYearParsableIEn.Count() == 1 ? ParseBuildYearToInt(buildYearParsableIEn, Link) : 0;
            NumberOfRooms = numberOfRoomsIEn.Count() == 1 ? numberOfRoomsIEn.First().ParseToIntLogIfCant() : 0;

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

            var mapLink = GetMapLink();
            MapLink = mapLink.Any() ? mapLink.First() : "";
        }

        private void ScrapePrice()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var priceStr = GetPriceStr();

            Price = priceStr.Any() ? priceStr.First().Substring(1).Replace(" ", "").ParseToDoubleLogIfCant() : 0;
        }

        private void ScrapeImage()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }
            var image = GetImage();
            var Image = image.Any() ? image.First() : "";
        }

        private IEnumerable<string> GetImage()
        {
            var image = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => x.ParentElement.LocalName == "section")
                .Where(x => x.ParentElement.ClassList.Contains("inner-post-page-cover"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            LogIfCountIncorrect(image, "AdImage", Link);

            return image;
        }

        private IEnumerable<IElement> GetBuildingInfoLinesHtml()
        {
            var buildingInfoLinesHtml = Document.All
                .Where(x => x.ClassName == "label")
                .Where(x => x.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ClassList.Contains("k-classified-icon-item"));

            return buildingInfoLinesHtml;
        }

        private IEnumerable<string> GetMapLink()
        {
            var mapLink = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => ((IHtmlAnchorElement)x).HostName == "maps.google.com")
                .Where(x => x.ParentElement.LocalName == "li")
                .Where(x => x.ParentElement.ClassList.Contains("li-map-preview"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            LogIfCountIncorrect(mapLink, "MapLink", Link);

            return mapLink;
        }

        private IEnumerable<string> GetPriceStr()
        {
            var priceStr = Document.All
                .Where(x => x.LocalName == "div")
                .Where(x => x.ClassList.Contains("price"))
                .Select(x => x.TextContent);

            LogIfCountIncorrect(priceStr, "Price", Link);

            return priceStr;
        }
    }
}
