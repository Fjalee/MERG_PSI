using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
        public string Price { get; set; }
        public InsideAdScraper()
        {
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
            //fix error handeling
            if (Document == null)
            {
                MessageBox.Show("error, func scrapeBuildingInfo, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //fix error handeling
            if (Document == null)
            {
                MessageBox.Show("error, func scrapeMapLink, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //fix error handeling
            if (Document == null)
            {
                MessageBox.Show("error, func ScrapePrice, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var classContent = GetPriceHtml();

            if (classContent.Any())
            {
                if (classContent.Count() != 1)
                {
                    MessageBox.Show("error, ScrapeMapCoord()", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Price = classContent.First().TextContent;
            }
            else
            {
                Price = "";
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
            catch (System.NullReferenceException)
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
                Floor = "";
                /*fix log */
            }
            if (areaIEn.Count() == 1)
            {
                Area = areaIEn.First().Value.parseToDoubleLogIfCant();
            }
            else {
                Area = 0;
                /*fix log */
            }
            if (pricePerSqMIEn.Count() == 1)
            {
                PricePerSqM = pricePerSqMIEn.First().Value.parseToDoubleLogIfCant();
            }
            else {
                PricePerSqM = 0;
                /*fix log*/
            }
            if (numberOfRoomsIEn.Count() == 1)
            {
                NumberOfRooms = numberOfRoomsIEn.First().Value.parseToIntLogIfCant();
            }
            else {
                NumberOfRooms = 0;
                /*fix log*/
            }
            if (buildYearParsableIEn.Count() == 1)
            {
                BuildYear = buildYearParsableIEn.First().Value.parseToIntLogIfCant();
            }
            else {
                BuildYear = 0;
                /*fix log*/
            }


            if (Floor == "" || Area == 0 || PricePerSqM == 0 || NumberOfRooms == 0 || BuildYear == 0)
            {
                //fix log
            }
        }
    }
}
