using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    abstract class SiteScraper
    {
        public List<RealEstate> ScrapedRealEstate { get; } = new List<RealEstate>();
        protected string WebsiteLink { get; }
        protected string Subdirectory { get; }
        protected string PageString { get; }
        protected string Symbol { get; }
        protected bool ReachedPageNoAds { get; set; } = false;

        public SiteScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString, string symbol)
        {
            ScrapingDomain += myUI.OnScrapingDomain;
            WebsiteLink = websiteLink;
            Subdirectory = subdirectory;
            PageString = pageString;
            Symbol = symbol;
        }

        public event EventHandler<ScrapingDomainEventArgs> ScrapingDomain;

        public async Task ScrapeWebsite()
        {
            var websitePage = 1;
            //while (!ReachedPageNoAds)
            while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = WebsiteLink + Subdirectory + Symbol + PageString + websitePage.ToString();

                ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(linkWithPage));

                var adCardLinkScraper = InstanciateAdCardLinkScraperObject();
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();
                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var ias = InstanciateInsideAdScraperObject(link);
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        if (IsAdHasAllNeededData(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.Latitude, ias.Longitude))
                        {
                            ScrapedRealEstate.Add(new RealEstate(link: link, area: ias.Area, pricePerSqM: ias.PricePerSqM, numberOfRooms: ias.NumberOfRooms,
                            floor: ias.Floor, scrapedPrice: ias.Price, mapLink: ias.MapLink, buildYear: ias.BuildYear, image: ias.Image, latitude: ias.Latitude, longitude: ias.Longitude));
                        }

                        else
                        {
                            MyLog.AdInvalid(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, "", "", ias.Latitude, ias.Longitude);
                        }
                    }
                    websitePage++;
                }
                else { ReachedPageNoAds = true; }
            }
        }

        protected abstract AdCardLinkScraper InstanciateAdCardLinkScraperObject();

        protected abstract InsideAdScraper InstanciateInsideAdScraperObject(string link);

        protected bool IsAdHasAllNeededData(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, double latitude, double longitude)
        {
            var calculatedPrice = pricePerSqM * area;
            if (
                latitude == 0 ||
                longitude == 0 ||
                link == "" ||
                mapLink == "" ||
                numberOfRooms == 0 ||
                (calculatedPrice == 0 && scrapedPrice == 0) ||
                !IsValuesClose(calculatedPrice, scrapedPrice, 1000))
            {
                return false;
            }
            else { return true; }
        }

        protected bool IsValuesClose(double value1, double value2, int roundErr)
        {
            var diff = value1 - value2;
            if ((diff < roundErr && diff >= 0) || (diff <= 0 && diff > -roundErr))
            {
                return true;
            }
            else { return false; }
        }
    }
}
