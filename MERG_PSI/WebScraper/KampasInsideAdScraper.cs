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
                var mapCoords = ParseMapLinkToCoords(MapLink);
                Latitude = mapCoords[0];
                Longitude = mapCoords[1];
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

        protected override double[] ParseMapLinkToCoords(string linkString)
        {
            var link = new Uri(linkString);
            var location = HttpUtility.ParseQueryString(link.Query).Get("q");

            if (Regex.IsMatch(location, @"^[0-9,.-]+$"))
            {
                return SplitCoordinates(location);
            }
            else
            {
                return new double[2] { 0, 0 };
            }
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

            MapLink = GetMapLink();
        }

        private void ScrapePrice()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            Price = GetPriceStr().Substring(1).Replace(" ", "").ParseToDoubleLogIfCant();
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
            var imageIEn = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => x.ParentElement.LocalName == "section")
                .Where(x => x.ParentElement.ClassList.Contains("inner-post-page-cover"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            LogIfCountIncorrect(imageIEn, "AdImage", Link);

            return imageIEn.Any() ? imageIEn.First() : "";
        }

        private IEnumerable<IElement> GetBuildingInfoLinesHtml()
        {
            var buildingInfoLinesHtml = Document.All
                .Where(x => x.ClassName == "label")
                .Where(x => x.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ClassList.Contains("k-classified-icon-item"));

            return buildingInfoLinesHtml;
        }

        private string GetMapLink()
        {
            var mapLinkIen = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => ((IHtmlAnchorElement)x).HostName == "maps.google.com")
                .Where(x => x.ParentElement.LocalName == "li")
                .Where(x => x.ParentElement.ClassList.Contains("li-map-preview"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            LogIfCountIncorrect(mapLinkIen, "MapLink", Link);

            return mapLinkIen.Any() ? mapLinkIen.First() : "";
        }

        private string GetPriceStr()
        {
            var priceStrIen = Document.All
                .Where(x => x.LocalName == "div")
                .Where(x => x.ClassList.Contains("price"))
                .Select(x => x.TextContent);

            LogIfCountIncorrect(priceStrIen, "Price", Link);

            return priceStrIen.Any() ? priceStrIen.First() : "€0";
        }
    }
}
