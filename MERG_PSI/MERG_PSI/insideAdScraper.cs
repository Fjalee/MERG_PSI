using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.Text.RegularExpressions;

namespace MERG_PSI
{
    class InsideAdScraper : Scraper
    {
        public override IHtmlDocument Document { get; set; }
        private readonly Dictionary<string, string> _buildingInfo = new Dictionary<string, string>();
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public int BuildYear { get; set; }
        public string MapLink { get; set; }
        public string MapCoords { get; set; }
        public double Price { get; set; }
        private readonly string _link;
        public InsideAdScraper(string link)
        {
            _link = link;
        }

        public override void Scrape()
        {
            ScrapeBuildingInfo();
            ScrapePrice();
            ScrapeMapLink();

            if (MapLink != "")
            {
                MapCoords = ParseMapLinkToCoords(MapLink);
            }
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

        private void ScrapePrice()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var priceStr = GetPriceStr();

            Price = priceStr.Any() ? priceStr.First().Substring(1).Replace(" ", "").ParseToDoubleLogIfCant() : 0;
        }

        private IEnumerable<IElement> GetBuildingInfoLinesHtml()
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = Document.All.Where(x =>
                x.ClassName == "label" &&
                x.ParentElement.LocalName == "div" &&
                x.ParentElement.ClassList.Contains("k-classified-icon-item"));

            return htmlClassContent;
        }

        private IEnumerable<string> GetMapLink()
        {
            var mapLink = Document.All
                .Where(x =>
                    x.LocalName == "a" &&
                    ((IHtmlAnchorElement)x).HostName == "maps.google.com" &&
                    x.ParentElement.LocalName == "li" &&
                    x.ParentElement.ClassList.Contains("li-map-preview"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            if (mapLink.Count() != 1 && mapLink.Count() != 0)
            {
                MessageBox.Show("error, ScrapeMapCoords()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return mapLink;
        }

        private IEnumerable<string> GetPriceStr()
        {
            var priceStr = Document.All
                .Where(x =>
                    x.LocalName == "div" &&
                    x.ClassList.Contains("price"))
                .Select(x => x.TextContent);

            if (priceStr.Count() != 1 || priceStr.Count() != 0)
            {
                MessageBox.Show("error, ScrapeMapCoords()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return priceStr;
        }

        private void ParseBuildingInfoLineLabelFromVal(IElement lineHtml)
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

            _buildingInfo.Add(parsedLabel, parsedValue);
        }

        private String ParseMapLinkToCoords(string linkString)
        {
            var link = new Uri(linkString);
            var location = HttpUtility.ParseQueryString(link.Query).Get("q");

            if (Regex.IsMatch(location, @"^[0-9,.]+$"))
            {
                return location;
            }
            else
            {
                MyLog.DnContainCoords(_link);
                return "";
            }
        }

        private void DictionaryToProperties(Dictionary<string, string> dictionary)
        {
            var areaVals = dictionary.Where(x => x.Key == "Plotas m²:").Select(x => x.Value);
            var pricePerSqMVals = dictionary.Where(x => x.Key == "€/m²:").Select(x => x.Value);
            var numberOfRoomsVals = dictionary.Where(x => x.Key == "Kambariai:").Select(x => x.Value);
            var buildYearParsableVals = dictionary.Where(x => x.Key == "Statybų metai:").Select(x => x.Value);
            var floorVals = dictionary.Where(x => x.Key == "Aukštas:").Select(x => x.Value);

            if (floorVals.Count() == 1)
            {
                Floor = floorVals.First();
            }
            else
            {
                Floor = "";
                if (floorVals.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, floorVals.Count(), "Floor");
                }
            }

            if (areaVals.Count() == 1)
            {
                Area = areaVals.First().ParseToDoubleLogIfCant();
            }
            else
            {
                Area = 0;
                if (areaVals.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, areaVals.Count(), "Area");
                }
            }

            if (pricePerSqMVals.Count() == 1)
            {
                PricePerSqM = pricePerSqMVals.First().ParseToDoubleLogIfCant();
            }
            else
            {
                PricePerSqM = 0;
                if (pricePerSqMVals.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, pricePerSqMVals.Count(), "PricePerSqM");
                }
            }

            if (buildYearParsableVals.Count() == 1)
            {
                var buildYearString = buildYearParsableVals.First();
                if (buildYearString.Length >= 4)
                {
                    BuildYear = buildYearString.Substring(0, 4).ParseToIntLogIfCant();
                }
                else
                {
                    BuildYear = 0;
                    MyLog.Msg($"Build Year \"{buildYearString}\" Doesn't contain 4 characters\n{_link}");
                }
            }
            else
            {
                BuildYear = 0;
                if (buildYearParsableVals.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, buildYearParsableVals.Count(), "BuildYear");
                }
            }

            if (numberOfRoomsVals.Count() == 1)
            {
                NumberOfRooms = numberOfRoomsVals.First().ParseToIntLogIfCant();
            }
            else
            {
                NumberOfRooms = 0;
                if (numberOfRoomsVals.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, numberOfRoomsVals.Count(), "NumberOfRooms");
                }
            }
        }
    }
}
