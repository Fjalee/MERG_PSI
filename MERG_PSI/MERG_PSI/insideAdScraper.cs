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
using System.Xml;

namespace MERG_PSI
{
    class insideAdScraper
    {
        private string className, siteUrl;
        private IHtmlDocument document;

        private List<string> buildingInfoLabels = new List<string>();
        private List<string> buildingInfo = new List<string>();

        public insideAdScraper(string siteUrl, string className){
            this.siteUrl = siteUrl;
            this.className = className;
        }

        public void scrapeBuildingInfo()
        {
            //fix error handeling
            if (this.document == null){
                MessageBox.Show("error, func scrapeBuildingInfo, didnt get IHTMLDocument first", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var buildingInfoHtml = getBuildingInfoHtml(document);

            if (buildingInfoHtml.Any()){
                foreach (var element in buildingInfoHtml){
                    parseBuildingInfo(element.InnerHtml);
                }
            }
        }

        public void scrapeMapCoord(){
            
        }

        public async Task getIHtmlDoc(){
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            this.document = parser.ParseDocument(response);
        }

        private IEnumerable<IElement> getBuildingInfoHtml(IHtmlDocument document){
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains(className));

            return adCardHtml;
        }

        private void parseBuildingInfo(string buildingInfoHtml){
            var labelWithValueHtml = getElementContentHtml(buildingInfoHtml , "span");
            var parsedLabel = parseLabel(labelWithValueHtml);
            var parsedValue = getElementContentHtml(labelWithValueHtml, "strong");

            buildingInfoLabels.Add(parsedLabel);
            buildingInfo.Add(parsedValue);
        }

        private string getElementContentHtml (string stringHtml, string localName){
            var document = stringIntoIHtmlDoc(stringHtml);

            IEnumerable<IElement> value = null;
            value = document.All.Where(x =>
                x.LocalName == localName);

            var parsedValue = "no data";
            foreach (var element in value){
                parsedValue = element.InnerHtml;
            }
            return parsedValue;
        }

        private IHtmlDocument stringIntoIHtmlDoc(string stringHtml){
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(stringHtml);

            return document;
        }

        private string parseLabel(string labelWithHtml){
            
            //fix clean error handeling below
            if (labelWithHtml.Substring(0, 5).CompareTo("\n    ") != 0){
                MessageBox.Show("error parseLabel insideAdScraper Class", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelWithHtml = labelWithHtml.Substring(5);
            
            var labelEndIdentifier = ": <";
            var indexLabelEnd = (labelWithHtml.IndexOf(labelEndIdentifier));

            var label = labelWithHtml.Substring(0, indexLabelEnd);

            return label;
        }

        public string getBuildingInfo(){
            var buildingInfoString = "";

            var i = 0;
            foreach (var element in buildingInfoLabels){
                buildingInfoString = buildingInfoString + "\n" + element + " " + buildingInfo[i];
                i ++;
            }

            if (buildingInfoString.Length > 0){ buildingInfoString = buildingInfoString.Substring(1); }

            return buildingInfoString;
        }
    }
}
