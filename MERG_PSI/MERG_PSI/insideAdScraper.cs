using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MERG_PSI
{
    class InsideAdScraper
    {
        private string _siteUrl;

        private IHtmlDocument _document;

        public List<string> BuildingInfoLabels { get; set; }
        public List<string> BuildingInfo { get; set; }
        public string MapLink { get; set; }
        public string Price { get; set; }
        public InsideAdScraper(string siteUrl)
        {
            _siteUrl = siteUrl;

            BuildingInfo = new List<string>();
            BuildingInfoLabels = new List<string>();
        }

        public void ScrapeBuildingInfo()
        {
            //fix error handeling
            if (_document == null)
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

        public void ScrapeMapLink()
        {
            //fix error handeling
            if (_document == null)
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

        public void ScrapePrice()
        {
            //fix error handeling
            if (_document == null)
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

        private IEnumerable<IElement> GetMapLinkHtml()
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = (_document).All.Where(x =>
                x.LocalName == "a" &&
                ((IHtmlAnchorElement)x).HostName == "maps.google.com" &&
                x.ParentElement.LocalName == "li" &&
                x.ParentElement.ClassList.Contains("li-map-preview"));

            return htmlClassContent;
        }
        private IEnumerable<IElement> GetBuildingInfoLinesHtml()
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = _document.All.Where(x =>
                x.ClassName == "label" &&
                x.ParentElement.LocalName == "div" &&
                x.ParentElement.ClassList.Contains("k-classified-icon-item"));

            return htmlClassContent;
        }
        private IEnumerable<IElement> GetPriceHtml()
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = _document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains("price"));

            return htmlClassContent;
        }
        
        public async Task GetIHtmlDoc()
        {
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(_siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            _document = parser.ParseDocument(response);

            cancellationToken.Dispose();
            httpClient.Dispose();
        }

        private void ParseBuildingInfoLineLabelFromVal(IElement buildingInfoLineHtml)
        {
            var parsedValue = "";
            var parsedLabel = "";
            try
            {
                parsedValue = buildingInfoLineHtml.FirstElementChild.InnerHtml;

                var fullInfoLine = buildingInfoLineHtml.TextContent;
                parsedLabel = fullInfoLine.Substring(0, fullInfoLine.IndexOf(parsedValue)).Replace("\n", "").Trim();
            }
            catch (System.NullReferenceException)
            {
                var fullInfoLine = buildingInfoLineHtml.TextContent;
                parsedLabel = fullInfoLine.Replace("\n", "").Trim();
            }

            BuildingInfoLabels.Add(parsedLabel);
            BuildingInfo.Add(parsedValue);
        }

        public string GetBuildingInfo()
        {
            var buildingInfoString = "";

            var i = 0;
            foreach (var element in BuildingInfoLabels)
            {
                buildingInfoString = buildingInfoString + "\n" + element + " " + BuildingInfo[i];
                i++;
            }
            buildingInfoString = buildingInfoString + "\n" + Price;
            buildingInfoString = buildingInfoString + "\n" + MapLink;

            if (buildingInfoString.Length > 0) { buildingInfoString = buildingInfoString.Substring(1); }

            return buildingInfoString;
        }
    }
}
