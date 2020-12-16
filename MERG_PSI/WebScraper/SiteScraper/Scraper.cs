using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebScraper
{
    public abstract class Scraper
    {
        public IHtmlDocument Document { get; set; }
        protected ILog Logger { get; }

        public Scraper(ILog logger)
        {
            Logger = logger;
        }

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