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
        private string className, siteUrl;
        private IHtmlDocument document;

        private List<string> buildingInfoLabels = new List<string>();
        private List<string> buildingInfo = new List<string>();
        private string mapCoord;

        public InsideAdScraper(string siteUrl, string className)
        {
            this.siteUrl = siteUrl;
            this.className = className;
        }

        public void ScrapeBuildingInfo()
        {
            //fix error handeling
            if (this.document == null)
            {
                MessageBox.Show("error, func scrapeBuildingInfo, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var buildingInfoHtml = GetHtmlClassContent(this.document, "div", this.className);

            if (buildingInfoHtml.Any())
            {
                foreach (var element in buildingInfoHtml)
                {
                    ParseBuildingInfo(element.InnerHtml);
                }
            }
        }

        public void ScrapeMapCoord()
        {
            //fix error handeling
            if (this.document == null)
            {
                MessageBox.Show("error, func scrapeMapCoord, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var liClassContent = GetHtmlClassContent(document, "li", "li-map-preview");

            if (liClassContent.Count() != 1)
            {
                MessageBox.Show("error, ScrapeMapCoord()", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mapCoord = GetHrefFromAnchor(liClassContent.First());
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
        }

        private IEnumerable<IElement> GetHtmlClassContent(IHtmlDocument document, string localName, string className)
        {
            IEnumerable<IElement> htmlClassContent = null;

            htmlClassContent = document.All.Where(x =>
                x.LocalName == localName &&
                x.ClassList.Contains(className));

            return htmlClassContent;
        }
        
        private void ParseBuildingInfo(string buildingInfoHtml)
        {
            var labelWithValueHtml = GetElementContentHtml(buildingInfoHtml, "span");
            var parsedLabel = ParseLabel(labelWithValueHtml);
            var parsedValue = GetElementContentHtml(labelWithValueHtml, "strong");

            buildingInfoLabels.Add(parsedLabel);
            buildingInfo.Add(parsedValue);
        }

        private string GetElementContentHtml(string stringHtml, string localName)
        {
            var document = StringIntoIHtmlDoc(stringHtml);

            IEnumerable<IElement> value = null;
            value = document.All.Where(x =>
                x.LocalName == localName);

            var parsedValue = "no data";
            foreach (var element in value)
            {
                parsedValue = element.InnerHtml;
            }
            return parsedValue;
        }

        private IHtmlDocument StringIntoIHtmlDoc(string stringHtml)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(stringHtml);

            return document;
        }

        private string ParseLabel(string labelWithHtml)
        {

            //fix clean error handeling below
            if (labelWithHtml.Substring(0, 5).CompareTo("\n    ") != 0)
            {
                MessageBox.Show("error parseLabel insideAdScraper Class", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelWithHtml = labelWithHtml.Substring(5);

            var labelEndIdentifier = ": <";
            var indexLabelEnd = (labelWithHtml.IndexOf(labelEndIdentifier));

            var label = labelWithHtml.Substring(0, indexLabelEnd);

            return label;
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

            if (buildingInfoString.Length > 0) { buildingInfoString = buildingInfoString.Substring(1); }

            return buildingInfoString;
        }
    }
}
