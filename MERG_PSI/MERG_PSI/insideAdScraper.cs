using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MERG_PSI
{
    class InsideAdScraper : Scraper
    {
        public IHtmlDocument Document { get; set; }
        private Dictionary<string, string> _buildingInfo;
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public string Municipality { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }
        public string MapLink { get; set; }
        public double Price { get; set; }
        private string _link;
        public InsideAdScraper(string link)
        {
            _link = link;
            _buildingInfo = new Dictionary<string, string>();

            //fix
            Municipality = "";
            Street = "";
        }

        public override void Scrape()
        {
            ScrapeBuildingInfo();
            ScrapePrice();
            ScrapeMapLink();

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

            var mapLinkHtml = GetMapLinkHtml();

            if (mapLinkHtml.Any())
            {
                if (mapLinkHtml.Count() != 1)
                {
                    MessageBox.Show("error, ScrapeMapCoord()", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MapLink = ((IHtmlAnchorElement)mapLinkHtml.First()).Href;
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
                    MessageBox.Show("error, ScrapeMapCoord()", "Error",
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
        private IEnumerable<IElement> GetMapLinkHtml()
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = (Document).All.Where(x =>
                x.LocalName == "a" &&
                ((IHtmlAnchorElement)x).HostName == "maps.google.com" &&
                x.ParentElement.LocalName == "li" &&
                x.ParentElement.ClassList.Contains("li-map-preview"));

            return htmlClassContent;
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
            var parsedLabel = "";
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
                if (floorIEn.Count() != 0)
                {
                    Floor = "";
                    MyLog.IEnCountInvalid(_link, floorIEn.Count(), "Floor");
                }
            }

            if (areaIEn.Count() == 1)
            {
                Area = areaIEn.First().Value.ParseToDoubleLogIfCant();
            }
            else
            {
                if (areaIEn.Count() != 0)
                {
                    Area = 0;
                    MyLog.IEnCountInvalid(_link, areaIEn.Count(), "Area");
                }
            }

            if (pricePerSqMIEn.Count() == 1)
            {
                PricePerSqM = pricePerSqMIEn.First().Value.ParseToDoubleLogIfCant();
            }
            else
            {
                if (pricePerSqMIEn.Count() != 0)
                {
                    PricePerSqM = 0;
                    MyLog.IEnCountInvalid(_link, pricePerSqMIEn.Count(), "PricePerSqM");
                }
            }

            if (buildYearParsableIEn.Count() == 1)
            {
                BuildYear = buildYearParsableIEn.First().Value.Substring(0,4).ParseToIntLogIfCant();
            }
            else
            {
                if (buildYearParsableIEn.Count() != 0)
                {
                    BuildYear = 0;
                    MyLog.IEnCountInvalid(_link, buildYearParsableIEn.Count(), "BuildYear");
                }
            }

            if (numberOfRoomsIEn.Count() == 1)
            {
                NumberOfRooms = numberOfRoomsIEn.First().Value.ParseToIntLogIfCant();
            }
            else
            {
                if (numberOfRoomsIEn.Count() != 0)
                {
                    NumberOfRooms = 0;
                    MyLog.IEnCountInvalid(_link, numberOfRoomsIEn.Count(), "NumberOfRooms");
                }
            }
        }
    }
}
