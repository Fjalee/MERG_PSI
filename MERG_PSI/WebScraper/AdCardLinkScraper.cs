using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    abstract class AdCardLinkScraper : Scraper
    {
        public string _siteUrl { get; set; }
        public string _classNameForAdCard { get; set; }
        public override IHtmlDocument Document { get; set; }
        public List<string> Links { get; set; } = new List<string>();

        public override void Scrape()
        {
            ScrapeUrls();
        }

        private void ScrapeUrls()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var adCardsPaths = GetAdCardsPaths();

            Links = ParseAllLinks(adCardsPaths);
        }

        public abstract IEnumerable<string> GetAdCardsPaths();

        private List<string> ParseAllLinks(IEnumerable<string> adCardsPaths)
        {
            var allLinks = new List<string>();

            if (adCardsPaths.Any())
            {
                foreach (var path in adCardsPaths)
                {
                    var url = _siteUrl + path;
                    allLinks.Add(url);
                }
            }

            return allLinks;
        }
    }
}
