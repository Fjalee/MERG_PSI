using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    public abstract class AdCardLinkScraper : Scraper
    {
        public List<string> Links { get; set; } = new List<string>();
        protected string ClassNameForAdCard { get; }
        private readonly string _siteUrl;

        public AdCardLinkScraper(string siteUrl, string classNameForAdCard, ILog logger) : base(logger)
        {
            _siteUrl = siteUrl;
            ClassNameForAdCard = classNameForAdCard;
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
                Logger.ErrorNoDocument();
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