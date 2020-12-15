namespace WebScraper
{
    public class DomosplusScraper : SiteScraper
    {
        public DomosplusScraper(/*Form1 myUI,*/ ILog logger)
            : base(/*myUI,*/ @"https://domoplius.lt", @"/skelbimai/butai?action_type=1", @"page_nr=", "&", logger) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject() => new DomoplusAdCardLinkScraper(WebsiteLink, "item", Logger);

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link) => new DomosplusInsideAdScraper(link, Logger);
    }
}
