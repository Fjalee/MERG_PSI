using System;
using System.Collections.Generic;
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
            while (!_reachedPageNoAds)
            //while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = _websiteLink + _subdirectory + "/" + _pageString + websitePage.ToString();
                ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(linkWithPage));
            }
        }
    }
}
