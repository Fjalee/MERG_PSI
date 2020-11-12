using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public class KampasScraper : SiteScraper
    {
        override public event EventHandler<ScrapingDomainEventArgs> ScrapingDomain;

        public KampasScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString)
        {
            ScrapingDomain += myUI.OnScrapingDomain;
            _websiteLink = websiteLink;
            _subdirectory = subdirectory;
            _pageString = pageString;
        }

        public async Task ScrapeKampasWebsite()
        {
            var websitePage = 1;
            //while (!_reachedPageNoAds)
            while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = _websiteLink + _subdirectory + "?" + _pageString + websitePage.ToString();
                ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(linkWithPage));

                var adCardLinkScraper = new KampasAdCardLinkScraper(_websiteLink, "k-ad-card-wide");
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();

                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var ias = new KampasInsideAdScraper(link);
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
