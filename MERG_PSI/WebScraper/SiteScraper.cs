using System;
using System.Collections.Generic;

namespace WebScraper
{
    public abstract class SiteScraper
    {
        public List<RealEstate> ScrapedRealEstate { get; } = new List<RealEstate>();
        protected string WebsiteLink { get; }
        protected string Subdirectory { get; }
        protected string PageString { get; }
        protected bool ReachedPageNoAds { get; set; } = false;

        public SiteScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString)
        {
            ScrapingDomain += myUI.OnScrapingDomain;
            WebsiteLink = websiteLink;
            Subdirectory = subdirectory;
            PageString = pageString;
        }

        public event EventHandler<ScrapingDomainEventArgs> ScrapingDomain;

        protected void RaiseScrapingDomainEvent(string link)
        {
            ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(link));
        }

        protected bool IsAdHasAllNeededData(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string mapCoords)
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
