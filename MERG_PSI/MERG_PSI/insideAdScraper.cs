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
        private string siteUrl;
        private IHtmlDocument document;

        private List<string> buildingInfoLabels = new List<string>();
        private List<string> buildingInfo = new List<string>();
        private string mapLink;
        private string price;

        public InsideAdScraper(string siteUrl)
        {
            this.siteUrl = siteUrl;
        }

        public void ScrapeBuildingInfo(string className)
        {
            //fix error handeling
            if (this.document == null)
            {
                MessageBox.Show("error, func scrapeBuildingInfo, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var buildingInfoHtml = GetHtmlClassContent(this.document, "div", className);

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
            if (this.document == null)
            {
                MessageBox.Show("error, func scrapeMapLink, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var liClassContent = GetHtmlClassContent(document, "li", className);

            if (liClassContent.Count() == 0)
            {
                mapLink = "";
            }
            else if (liClassContent.Count() != 1)
            {
                MessageBox.Show("error, ScrapeMapCoord()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mapLink = GetHrefFromAnchor(liClassContent.First());
            }
        }

        public void ScrapePrice(string className)
        {
            //fix error handeling
            if (this.document == null)
            {
                MessageBox.Show("error, func ScrapePrice, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var classContent = GetHtmlClassContent(document, "div", className);

            if (classContent.Count() == 0)
            {
                price = "";
            }
            else if (classContent.Count() != 1)
            {
                MessageBox.Show("error, ScrapeMapCoord()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                price = classContent.First().TextContent;
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

            var request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            this.document = parser.ParseDocument(response);

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

            buildingInfoLabels.Add(parsedLabel);
            buildingInfo.Add(parsedValue);
        }

        public string GetBuildingInfo()
        {
            var buildingInfoString = "";

            var i = 0;
            foreach (var element in buildingInfoLabels)
            {
                buildingInfoString = buildingInfoString + "\n" + element + " " + buildingInfo[i];
                i++;
            }
            buildingInfoString = buildingInfoString + "\n" + price;
            buildingInfoString = buildingInfoString + "\n" + mapLink;

            if (buildingInfoString.Length > 0) { buildingInfoString = buildingInfoString.Substring(1); }

            return buildingInfoString;
        }
    }
}
