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
    class AdCardLinkScraper
    {
        private string siteUrl, siteUrlWithPage, className;
        private IHtmlDocument document;
        private List<string> links = new List<string>();

        public AdCardLinkScraper(string siteUrl, string siteUrlWithPage, string className)
        {
            this.siteUrl = siteUrl;
            this.siteUrlWithPage = siteUrlWithPage;
            this.className = className;
        }

        public void ScrapeUrls()
        {

            //fix error handeling
            if (this.document == null)
            {
                MessageBox.Show("error, func scrapeUrls, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var adCardHtml = GetAdCardHtml(document);

            CreateLinkList(adCardHtml);
        }

        public async Task GetIHtmlDoc()
        {
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrlWithPage);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            this.document = parser.ParseDocument(response);
        }

        private IEnumerable<IElement> GetAdCardHtml(IHtmlDocument document)
        {
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains(className));

            return adCardHtml;
        }

        void CreateLinkList(IEnumerable<IElement> adCardHtml)
        {
            if (adCardHtml.Any())
            {
                foreach (var element in adCardHtml)
                {
                    links.Add(ParseLink(element.InnerHtml, siteUrl));
                }
            }
        }

        private string ParseLink(string cardHtml, string siteUrl)
        {
            var document = StringIntoIHtmlDoc(cardHtml);
            var urlSubDirEndParsed = GetHref(document);

            var urlSubDirStringToBeDeleted = "about://";
            var nmCharToBeDeleted = urlSubDirStringToBeDeleted.Length;
            var urlSubDir = urlSubDirEndParsed.Substring(nmCharToBeDeleted);

            //fix add error handling

            var url = siteUrl + urlSubDir;
            return url;
        }

        private string GetHref(IHtmlDocument document)
        {
            var menuItems = document.QuerySelectorAll("a");
            var links = menuItems.Select(m => ((IHtmlAnchorElement)m).Href).ToList();

            //fix error handeling
            if (links.Count == 2)
            {
                if (links[0] != links[1])
                {
                    MessageBox.Show("error2, func GetHref", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (links.Count != 1 && links.Count != 2)
            {
                MessageBox.Show("error, func GetHref", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return links[0];
        }

        private IHtmlDocument StringIntoIHtmlDoc(string stringHtml)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(stringHtml);

            return document;
        }

        public List<string> GetUrls()
        {
            return links;
        }
    }
}