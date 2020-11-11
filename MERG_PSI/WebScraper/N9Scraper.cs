using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public class N9Scraper : SiteScraper
    {
        override public event EventHandler<ScrapingDomainEventArgs> ScrapingDomain;
        public List<RealEstate> ScrapedRealEstate { get; set; } = new List<RealEstate>();
        private bool _reachedPageNoAds = false;

        public N9Scraper(Form1 myUI, string websiteLink, string subdirectory, string pageString)
        {
            ScrapingDomain += myUI.OnScrapingDomain;
            _websiteLink = websiteLink;
            _subdirectory = subdirectory;
            _pageString = pageString;
        }

        public async Task ScrapeN9Website()
        {
            var websitePage = 1;
            //while (!_reachedPageNoAds)
            while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = _websiteLink + _subdirectory + "&" + _pageString + websitePage.ToString() + "&slist = 100584040";
                ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(linkWithPage));

                var adCardLinkScraper = new DomoplusAdCardLinkScraper(_websiteLink, "item");
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();

                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var ias = new InsideAdScraper2(link);
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        if (IsAdHasAllNeededData(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.MapCoords))
                        {
                            ScrapedRealEstate.Add(new RealEstate(link: link, area: ias.Area, pricePerSqM: ias.PricePerSqM, numberOfRooms: ias.NumberOfRooms,
                            floor: ias.Floor, scrapedPrice: ias.Price, mapLink: ias.MapLink, buildYear: ias.BuildYear, mapCoords: ias.MapCoords)); //fix Municipality, Street instead of "", ""
                        }

                        else
                        {
                            MyLog.AdInvalid(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, "", "", ias.MapCoords); //fix Municipality, Street instead of "", ""
                        }

                    }
                    websitePage++;
                }
                else { _reachedPageNoAds = true; }
            }
        }
    }
}
