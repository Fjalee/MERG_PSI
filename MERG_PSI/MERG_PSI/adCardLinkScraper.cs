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
        private string _siteUrl, _siteUrlWithPage, _className;
        private IHtmlDocument _document;
        public List<string> Links { get; set; }

        public AdCardLinkScraper(string siteUrl, string siteUrlWithPage, string className)
        {
            _siteUrl = siteUrl;
            _siteUrlWithPage = siteUrlWithPage;
            _className = className;
            Links = new List<string>(); 
        }

        public void ScrapeUrls()
        {

            //fix error handeling
            if (_document == null)
            {
                MessageBox.Show("error, func scrapeUrls, didnt get IHTMLDocument first", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var adCardHtml = GetAdCardHtml(_document);

            CreateLinkList(adCardHtml);
        }

        public async Task GetIHtmlDoc()
        {
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(_siteUrlWithPage);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            _document = parser.ParseDocument(response);

            cancellationToken.Dispose();
            httpClient.Dispose();
        }

        private IEnumerable<IElement> GetAdCardHtml(IHtmlDocument document)
        {
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains(_className));

            return adCardHtml;
        }

        void CreateLinkList(IEnumerable<IElement> adCardHtml)
        {
            if (adCardHtml.Any())
            {
                foreach (var element in adCardHtml)
                {
                    Links.Add(ParseLink(element.InnerHtml, _siteUrl));
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

            //fix error handling
            if (urlSubDirEndParsed.Substring(0, nmCharToBeDeleted) != urlSubDirStringToBeDeleted)
            {
                MessageBox.Show("error, func ParseLink", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //fix add error handling

            var url = siteUrl + urlSubDir;
            return url;
        }

        private string GetHref(IHtmlDocument document)
        {
            var menuItems = document.QuerySelectorAll("a");
            var Links = menuItems.Select(m => ((IHtmlAnchorElement)m).Href).ToList();

            //fix error handeling
            if (Links.Count == 2)
            {
                if (Links[0] != Links[1])
                {
                    MessageBox.Show("error2, func GetHref", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Links.Count != 1 && Links.Count != 2)
            {
                MessageBox.Show("error, func GetHref", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return Links[0];
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
            return Links;
        }
    }
}