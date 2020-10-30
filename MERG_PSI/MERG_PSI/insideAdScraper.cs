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

            DictionaryToProperties(_buildingInfo);
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
        }

        private void ScrapeMapLink()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var mapLinks = GetMapLinks();

            if (mapLinks.Any())
            {
                if (mapLinks.Count() != 1)
                {
                    MessageBox.Show("error, ScrapeMapCoords()", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MapLink = "";
            }
        }

        private void ScrapePrice()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var classContent = GetPriceHtml();

            if (classContent.Any())
            {
                if (classContent.Count() != 1)
                {
                    MessageBox.Show("error, ScrapeMapCoords()", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var priceStrContainsOnlyDigits = classContent.First().TextContent.Substring(1).Replace(" ", "");
                Price = priceStrContainsOnlyDigits.ParseToDoubleLogIfCant();
            }
            else
            {
                Price = 0;
            }
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

        private IEnumerable<string> GetMapLinks()
        {
            var mapLink = Document.All
                .Where(x =>
                    x.LocalName == "a" &&
                    ((IHtmlAnchorElement)x).HostName == "maps.google.com" &&
                    x.ParentElement.LocalName == "li" &&
                    x.ParentElement.ClassList.Contains("li-map-preview"))
                .Select(x => ((IHtmlAnchorElement)x).Href);

            return mapLink;
        }

        private IEnumerable<IElement> GetPriceHtml()
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = Document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains("price"));

            return htmlClassContent;
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
            var areaIEn = dictionary.Where(x => x.Key == "Plotas m²:");
            var pricePerSqMIEn = dictionary.Where(x => x.Key == "€/m²:");
            var numberOfRoomsIEn = dictionary.Where(x => x.Key == "Kambariai:");
            var buildYearParsableIEn = dictionary.Where(x => x.Key == "Statybų metai:");
            var floorIEn = dictionary.Where(x => x.Key == "Aukštas:");

            if (floorIEn.Count() == 1)
            {
                Floor = floorIEn.First().Value;
            }
            else
            {
                Floor = "";
                if (floorIEn.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, floorIEn.Count(), "Floor");
                }
            }

            if (areaIEn.Count() == 1)
            {
                Area = areaIEn.First().Value.ParseToDoubleLogIfCant();
            }
            else
            {
                Area = 0;
                if (areaIEn.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, areaIEn.Count(), "Area");
                }
            }

            if (pricePerSqMIEn.Count() == 1)
            {
                PricePerSqM = pricePerSqMIEn.First().Value.ParseToDoubleLogIfCant();
            }
            else
            {
                PricePerSqM = 0;
                if (pricePerSqMIEn.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, pricePerSqMIEn.Count(), "PricePerSqM");
                }
            }

            if (buildYearParsableIEn.Count() == 1)
            {
                var buildYearString = buildYearParsableIEn.First().Value;
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
                if (buildYearParsableIEn.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, buildYearParsableIEn.Count(), "BuildYear");
                }
            }

            if (numberOfRoomsIEn.Count() == 1)
            {
                NumberOfRooms = numberOfRoomsIEn.First().Value.ParseToIntLogIfCant();
            }
            else
            {
                NumberOfRooms = 0;
                if (numberOfRoomsIEn.Count() != 0)
                {
                    MyLog.IEnCountInvalid(_link, numberOfRoomsIEn.Count(), "NumberOfRooms");
                }
            }
        }
    }
}
