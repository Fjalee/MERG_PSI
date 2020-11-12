using System.Threading.Tasks;

namespace WebScraper
{
    public class AllScrapers
    {
        readonly Form1 _myUI;
        public AllScrapers(Form1 myUI)
        {
            _myUI = myUI;
        }

        public async Task ScrapeAllWebsites()
        {
            //var kampasScraper = new KampasScraper(_myUI, @"https://www.kampas.lt", @"/butai", @"page=");
            //await kampasScraper.ScrapeKampasWebsite();

            var n9Scraper = new DomosplusScraper(_myUI, @"https://domoplius.lt", @"/skelbimai/butai?action_type=1", @"page_nr=");
            await n9Scraper.ScrapeN9Website();

            //var output = new OutputToJson(kampasScraper.ScrapedRealEstate);
            var output = new OutputToJson(n9Scraper.ScrapedRealEstate);
            output.WriteToFile();
        }
    }
}
