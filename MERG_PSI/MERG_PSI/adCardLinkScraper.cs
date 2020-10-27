using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MERG_PSI
{
    class AdCardLinkScraper : Scraper
    {
        private string _siteUrl, _classNameForAdCard;
        public override IHtmlDocument Document { get; set; }
        public List<string> Links { get; set; }
        public AdCardLinkScraper(string siteUrl, string className)
        {
            _siteUrl = siteUrl;
            _classNameForAdCard = className;

            Links = new List<string>(); 
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