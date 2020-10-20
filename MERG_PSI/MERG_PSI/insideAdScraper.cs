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

        private List<string> _buildingInfoLabels = new List<string>();
        private List<string> _buildingInfo = new List<string>();
        private string _mapLink;
        private string _price;

        public InsideAdScraper(string siteUrl)
        {
            _siteUrl = siteUrl;
        }

        public void ScrapeBuildingInfo(string className)
        {
            //fix error handeling
            if (_document == null)
            {
                MessageBox.Show("error, func scrapeBuildingInfo, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var buildingInfoHtml = GetHtmlClassContent(_document, "div", className);

            if (buildingInfoHtml.Any())
            {
                foreach (var element in buildingInfoHtml)
                {
                    ParseBuildingInfo(element);
                }
            }
        }

        public void ScrapeMapLink(string className)
        {
            //fix error handeling
            if (_document == null)
            {
                MessageBox.Show("error, func scrapeMapLink, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var liClassContent = GetHtmlClassContent(_document, "li", className);

            if (liClassContent.Count() == 0)
            {
                _mapLink = "";
            }
            else if (liClassContent.Count() != 1)
            {
                MessageBox.Show("error, ScrapeMapCoord()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _mapLink = GetHrefFromAnchor(liClassContent.First());
            }
        }

        public void ScrapePrice(string className)
        {
            //fix error handeling
            if (_document == null)
            {
                MessageBox.Show("error, func ScrapePrice, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var classContent = GetHtmlClassContent(_document, "div", className);

            if (classContent.Count() == 0)
            {
                _price = "";
            }
            else if (classContent.Count() != 1)
            {
                MessageBox.Show("error, ScrapeMapCoord()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _price = classContent.First().TextContent;
            }
        }

        private string GetHrefFromAnchor(IElement anchor)
        {
            //fix error handling
            if (anchor.Children.Length != 1)
            {
                MessageBox.Show("error GetHrefFromAnchor() insideAdScraper Class", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ((IHtmlAnchorElement)anchor.Children.First()).Href;
        }

        private IEnumerable<IElement> GetHtmlClassContent(IHtmlDocument document, string localName, string className)
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = document.All.Where(x =>
                x.LocalName == localName &&
                x.ClassList.Contains(className));

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

        private void ParseBuildingInfo(IElement buildingInfoHtml)
        {
            var htmlChildren = buildingInfoHtml.Children.Where(x => x.InnerHtml != "");

            //fix error handling
            if (htmlChildren.Count() != 1)
            {
                MessageBox.Show("error GetHrefFromAnchor() insideAdScraper Class", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            var parsedValue = "";
            var parsedLabel = "";
            try
            {
                parsedValue = htmlChildren.First().FirstElementChild.InnerHtml;
                var fullInfoLine = htmlChildren.First().TextContent;
                parsedLabel = fullInfoLine.Substring(0, fullInfoLine.IndexOf(parsedValue)).Replace("\n", "").Trim();
            }
            catch (System.NullReferenceException)
            {
                var fullInfoLine = htmlChildren.First().TextContent;
                parsedLabel = fullInfoLine.Replace("\n", "").Trim();
            }

            _buildingInfoLabels.Add(parsedLabel);
            _buildingInfo.Add(parsedValue);
        }

        public string GetBuildingInfo()
        {
            var buildingInfoString = "";

            var i = 0;
            foreach (var element in _buildingInfoLabels)
            {
                buildingInfoString = buildingInfoString + "\n" + element + " " + _buildingInfo[i];
                i++;
            }
            buildingInfoString = buildingInfoString + "\n" + _price;
            buildingInfoString = buildingInfoString + "\n" + _mapLink;

            if (buildingInfoString.Length > 0) { buildingInfoString = buildingInfoString.Substring(1); }

            return buildingInfoString;
        }
    }
}
