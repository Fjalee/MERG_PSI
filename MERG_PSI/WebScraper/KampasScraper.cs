namespace WebScraper
{
    public class KampasScraper : SiteScraper
    {
        public KampasScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString, string symbol, ILog logger)
            : base(myUI, websiteLink, subdirectory, pageString, symbol, logger) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject()
        {
            return new KampasAdCardLinkScraper(WebsiteLink, "k-ad-card-wide", Logger);
        }

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link)
        {
            return new KampasInsideAdScraper(link, Logger);
        }
    }
}
