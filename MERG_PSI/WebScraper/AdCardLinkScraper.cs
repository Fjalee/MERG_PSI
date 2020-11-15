using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    abstract class AdCardLinkScraper : Scraper
    {
        public List<string> Links { get; set; } = new List<string>();
        protected readonly string _siteUrl;
        protected readonly string _classNameForAdCard;

        public AdCardLinkScraper(string siteUrl, string classNameForAdCard)
        {
            _siteUrl = siteUrl;
            _classNameForAdCard = classNameForAdCard;
        }

        public override void Scrape()
        {
            ScrapeUrls();
        }

        protected abstract IEnumerable<string> GetAdCardsPaths();

        private void ScrapeUrls()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            var adCardsPaths = GetAdCardsPaths();

            Links = ParseAllLinks(adCardsPaths);
        }

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
