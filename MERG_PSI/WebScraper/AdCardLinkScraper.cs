using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebScraper
{
    class AdCardLinkScraper : Scraper
    {
        private readonly string _siteUrl;
        private readonly string _classNameForAdCard;
        public override IHtmlDocument Document { get; set; }
        public List<string> Links { get; set; } = new List<string>();
        public AdCardLinkScraper(string siteUrl, string className)
        {
            _siteUrl = siteUrl;
            _classNameForAdCard = className;
        }

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

        private IEnumerable<string> GetAdCardsPaths()
        {
            var adCardsPaths = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => x.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ClassList.Contains(_classNameForAdCard))
                .Select(x => ((IHtmlAnchorElement)x).PathName);

            return adCardsPaths;
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