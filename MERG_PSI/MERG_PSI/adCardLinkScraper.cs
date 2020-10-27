using AngleSharp.Dom;
using AngleSharp.Html.Dom;using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MERG_PSI
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

            var adCardsHtml = GetAdCardsHtml();

            Links = ParseAllLinks(adCardsHtml);
        }

        private IEnumerable<IElement> GetAdCardsHtml()
        {
            IEnumerable<IElement> adCardsHtml = null;

            adCardsHtml = Document.All.Where(x =>
                x.LocalName == "a" &&
                x.ParentElement.LocalName == "div" &&
                x.ParentElement.ClassList.Contains(_classNameForAdCard));

            return adCardsHtml;
        }

        private List<string> ParseAllLinks(IEnumerable<IElement> adCardsHtml)
        {
            var allLinks = new List<string>();

            if (adCardsHtml.Any())
            {
                foreach (var element in adCardsHtml)
                {
                    var url = _siteUrl + ((IHtmlAnchorElement)element).PathName;
                    allLinks.Add(url);
                }
            }

            return allLinks;
        }
    }
}