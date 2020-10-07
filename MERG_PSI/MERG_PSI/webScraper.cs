using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace MERG_PSI {
    class WebScraper {

        private string siteUrl;
        private List<string> links = new List<string>();
        private string className;

        public WebScraper(string siteUrl, string className) {
            this.siteUrl = siteUrl;
            this.className = className;

            getLinks();
        }

        private async void getLinks() {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);

            IEnumerable<IElement> adCardHtml = getAdCardHtml(document);
            if(adCardHtml.Any()) { 
                foreach(var element in adCardHtml) {
                    links.Add(parseLink(element.InnerHtml));
                }
            }
        }

        private IEnumerable<IElement> getAdCardHtml(IHtmlDocument document) {
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.ClassName != null &&
                x.ClassName.Contains(className));

            return adCardHtml;
        }

        private string parseLink(string cardHtml) {
            var urlSubDirIdentifier = "<a href=\"";
            var indexUrlSubDirStart = (cardHtml.IndexOf(urlSubDirIdentifier)) + urlSubDirIdentifier.Length;
            var urlSubDirEndNotParsed = cardHtml.Substring(indexUrlSubDirStart);
            var indexUrlSubDirEnd = urlSubDirEndNotParsed.IndexOf("\"");
            var urlSubDir = urlSubDirEndNotParsed.Substring(0, indexUrlSubDirEnd);

            var url = siteUrl + urlSubDir;
            return url;
        }

        public List<string> getUrls() {
            return links;
        }
    }
}