namespace WebScraper
{
    public class DomosplusScraper : SiteScraper
    {
        public DomosplusScraper(ILog logger)
        : base(@"https://domoplius.lt", @"/skelbimai/butai?action_type=1", @"page_nr=", "&", logger) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject()
        {
            return new DomoplusAdCardLinkScraper(Logger);
        }

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link)
        {
            return new DomosplusInsideAdScraper(link, Logger);
        }
    }
}
