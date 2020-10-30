using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERG_PSI
{
    public class KampasScraper
    {
        private readonly string _websiteLink = "https://www.kampas.lt";
        private readonly string _subdirectory = "/butai";
        private readonly string _pageQueryString = "page=";
        public List<RealEstate> ScrapedRealEstate { get; set; } = new List<RealEstate>();
        private bool _reachedPageNoAds = false;

        public event EventHandler<ScrapingDomainEventArgs> ScrapingDomain;

        public KampasScraper(Form1 myUI)
        {
            ScrapingDomain += myUI.OnScrapingDomain;
        }

        public async Task ScrapeKampasWebsite()
        {
            var websitePage = 1;
            while (!_reachedPageNoAds)
            //while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = _websiteLink + _subdirectory + "?" + _pageQueryString + websitePage.ToString();
                ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(linkWithPage));

                var adCardLinkScraper = new AdCardLinkScraper(_websiteLink, "k-ad-card-wide");
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();

                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var ias = new InsideAdScraper(link);
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        if (IsAdHasAllNeededData(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.MapCoords))
                        {
                            ScrapedRealEstate.Add(new RealEstate(link: link, area: ias.Area, pricePerSqM: ias.PricePerSqM, numberOfRooms: ias.NumberOfRooms,
                            floor: ias.Floor, scrapedPrice: ias.Price, mapLink: ias.MapLink, buildYear: ias.BuildYear, mapCoords: ias.MapCoords)); //fix Municipality, Street instead of "", ""
                        }

                        else
                        {
                            MyLog.AdInvalid(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, "", ""); //fix Municipality, Street instead of "", ""
                        }
                    }
                    websitePage++;
                }
                else { _reachedPageNoAds = true; }
            }
        }

        private bool IsAdHasAllNeededData(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string mapCoords)
        {
            var calculatedPrice = pricePerSqM * area;
            if (
                //fix put area and priceerarea

                mapCoords == "" ||
                link == "" ||
                mapLink == "" ||
                numberOfRooms == 0 ||
                (calculatedPrice == 0 && scrapedPrice == 0) ||
                !IsValuesClose(calculatedPrice, scrapedPrice, 1000)
                /*Municipality == /*fix to be implemented*/
                /*Street == /*fix to be implemented*/)
            {
                return false;
            }
            else { return true; }
        }

        public bool IsValuesClose(double value1, double value2, int roundErr)
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
