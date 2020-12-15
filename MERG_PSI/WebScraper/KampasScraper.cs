namespace WebScraper
{
    public class KampasScraper : SiteScraper
    {
        public KampasScraper(/*Form1 myUI,*/ILog logger)
            : base(/*myUI, */@"https://www.kampas.lt", @"/butai", @"page=", "?", logger) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject()
        {
            return new KampasAdCardLinkScraper(Logger);
        }

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link)
        {
            return new KampasInsideAdScraper(link, Logger);
        }
    }
}