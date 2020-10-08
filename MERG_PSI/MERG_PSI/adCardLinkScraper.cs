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
    class adCardLinkScraper {
        private string siteUrl, siteUrlWithPage, className;
        private List<string> links = new List<string>();

        public adCardLinkScraper(string siteUrl, string siteUrlWithPage, string className) {
            this.siteUrl = siteUrl;
            this.siteUrlWithPage = siteUrlWithPage;
            this.className = className;
        }

        public async Task scrapeUrlsAsync(){

            var document = await getIHtmlDoc();

            var adCardHtml = getAdCardHtml(document);

            createLinkList(adCardHtml);
        }

        private async Task<IHtmlDocument> getIHtmlDoc(){
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrlWithPage);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(response);

            return document;
        }

        private IEnumerable<IElement> getAdCardHtml(IHtmlDocument document){
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains(className));

            return adCardHtml;
        }

        void createLinkList(IEnumerable<IElement> adCardHtml){
            if(adCardHtml.Any()) { 
                foreach(var element in adCardHtml) {
                    links.Add(parseLink(element.InnerHtml, siteUrl));
                }
            }
        }

        private string parseLink(string cardHtml, string siteUrl) {
            var urlSubDirIdentifier = "<a href=\"";
            var indexUrlSubDirStart = (cardHtml.IndexOf(urlSubDirIdentifier)) + urlSubDirIdentifier.Length;
            var urlSubDirEndNotParsed = cardHtml.Substring(indexUrlSubDirStart);
            var indexUrlSubDirEnd = urlSubDirEndNotParsed.IndexOf("\"");
            var urlSubDir = urlSubDirEndNotParsed.Substring(0, indexUrlSubDirEnd);

            var url = siteUrl + urlSubDir;
            return url;
        }

        public List<string> getUrls(){
            return links;
        }
    }
}