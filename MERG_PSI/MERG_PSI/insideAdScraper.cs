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
        private List<string> buildingInfo = new List<string>();

        public insideAdScraper(string siteUrl, string className)
        {
            getBuildingInfo(siteUrl, className);
        }

        private async void getBuildingInfo(string siteUrl, string className)
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);

            IEnumerable<IElement> adCardHtml = getBuildingInfoHtml(document, className);
            if (adCardHtml.Any())
            {
                foreach (var element in adCardHtml)
                {
                    buildingInfo.Add(parseBuildingInfo(element.InnerHtml));
                }
            }
        }

        private IEnumerable<IElement> getBuildingInfoHtml(IHtmlDocument document, string className)
        {
            IEnumerable<IElement> adCardHtml = null;

            adCardHtml = document.All.Where(x =>
                x.LocalName == "div" &&
                x.ClassList.Contains(className));

            return adCardHtml;
        }

        private string parseBuildingInfo(string buildingInfoHtml)
        {
            var valueEndIdentifier = "</strong";

            string[] arrayHtmlSplit = buildingInfoHtml.Split('>');

            var valueStartParsed = arrayHtmlSplit[(arrayHtmlSplit.Length)-3];

            var indexValueEnd = (valueStartParsed.IndexOf(valueEndIdentifier));
            var value = valueStartParsed.Substring(0, indexValueEnd);

            return value;
        }

        public List<string> getBuildingInfo()
        {
            return buildingInfo;
        }
    }
}
