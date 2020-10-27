using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MERG_PSI
{
    abstract class Scraper
    {
        public abstract IHtmlDocument Document { get; set; }
        public async Task<IHtmlDocument> GetIHtmlDoc(string siteUrl)
        {
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();

            cancellationToken.Dispose();
            httpClient.Dispose();

            return parser.ParseDocument(response);
        }

        public abstract void Scrape();
    }
}
