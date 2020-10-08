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
        public insideAdScraper(string siteUrl)
        {
            tempFunc(siteUrl);
        }

        private async void tempFunc(string siteUrl)
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);
        }
    }
}



//"k-classified-icon-item"
