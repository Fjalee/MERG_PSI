namespace WebScraper
{
    public class DomosplusScraper : SiteScraper
    {
        public DomosplusScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString, string symbol, ILog logger) : base(myUI, websiteLink, subdirectory, pageString, symbol, logger) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject() => new DomoplusAdCardLinkScraper(WebsiteLink, "item", Logger);

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link) => new DomosplusInsideAdScraper(link, Logger);
    }
}
