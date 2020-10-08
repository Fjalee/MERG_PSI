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

namespace MERG_PSI
{
    class insideAdScraper
    {
        private string className, siteUrl;

        private List<string> buildingInfo = new List<string>();

        public string size { get; set; }
        public string eurPerSq { get; set; }
        public string rooms { get; set; }
        public string floor { get; set; }
        public string construction { get; set; }
        public string isEquipped { get; set; }
        public string heating { get; set; }
        public string buildYear { get; set; }

        public insideAdScraper(string siteUrl, string className){
            this.siteUrl = siteUrl;
            this.className = className;
        }

        public async Task scrapeBuildingInfoAsync(){
            
            var document = await getIHtmlDoc();

            var buildingInfoHtml = getBuildingInfoHtml(document);

            createInfoList(buildingInfoHtml);
            listToStrings();
        }

        private async Task<IHtmlDocument> getIHtmlDoc(){
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(response);

            return document;
        }

        private IEnumerable<IElement> getBuildingInfoHtml(IHtmlDocument document){
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains(className));

            return adCardHtml;
        }

        private void createInfoList (IEnumerable<IElement> buildingInfoHtml){
            if (buildingInfoHtml.Any())
            {
                foreach (var element in buildingInfoHtml)
                {
                    buildingInfo.Add(parseBuildingInfo(element.InnerHtml));
                }
            }
        }

        private string parseBuildingInfo(string buildingInfoHtml){
            var valueEndIdentifier = "</strong";

            string[] arrayHtmlSplit = buildingInfoHtml.Split('>');

            var valueStartParsed = arrayHtmlSplit[(arrayHtmlSplit.Length)-3];
            
            var indexValueEnd = (valueStartParsed.IndexOf(valueEndIdentifier));

            var value = valueStartParsed.Substring(0, indexValueEnd);

            return value;
        }

        private void listToStrings(){
            size = buildingInfo[0];
            eurPerSq = buildingInfo[1];
            rooms = buildingInfo[2];
            floor = buildingInfo[3];
            construction = buildingInfo[4];
            isEquipped = buildingInfo[5];
            heating = buildingInfo[6];
            buildYear = buildingInfo[7];
        }
    }
}
