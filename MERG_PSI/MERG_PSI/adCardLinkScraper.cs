using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;

namespace MERG_PSI {
    class adCardLinkScraper {
        private string siteUrl, siteUrlWithPage, className;
        private IHtmlDocument document;
        private List<string> links = new List<string>();

        public adCardLinkScraper(string siteUrl, string siteUrlWithPage, string className) {
            this.siteUrl = siteUrl;
            this.siteUrlWithPage = siteUrlWithPage;
            this.className = className;
        }

        public void scrapeUrls(){

            //fix error handeling
            if (this.document == null){
                MessageBox.Show("error, func scrapeUrls, didnt get IHTMLDocument first", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var adCardHtml = getAdCardHtml(document);

            createLinkList(adCardHtml);
        }

        public async Task getIHtmlDoc(){
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrlWithPage);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            this.document = parser.ParseDocument(response);
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
            var document = stringIntoIHtmlDoc(cardHtml);
            var urlSubDirEndParsed = getHref(document);

            var urlSubDirStringToBeDeleted = "about://";
            var nmCharToBeDeleted = urlSubDirStringToBeDeleted.Length;
            var urlSubDir = urlSubDirEndParsed.Substring(nmCharToBeDeleted);

            //fix add error handling

            var url = siteUrl + urlSubDir;
            return url;
        }

        private string getHref (IHtmlDocument document){
            var menuItems = document.QuerySelectorAll("a");
            var links = menuItems.Select(m => ((IHtmlAnchorElement)m).Href).ToList();

            return links[0];
        }

        private IHtmlDocument stringIntoIHtmlDoc(string stringHtml){
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(stringHtml);

            return document;
        }

        public List<string> getUrls(){
            return links;
        }
    }
}