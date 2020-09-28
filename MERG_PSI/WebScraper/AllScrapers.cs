using System.Collections.Generic;
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
            var kampasScraper = new KampasScraper(_myUI, @"https://www.kampas.lt", @"/butai", @"page=");
            var task1 = kampasScraper.ScrapeKampasWebsite();

            var domosplusScraper = new DomosplusScraper(_myUI, @"https://domoplius.lt", @"/skelbimai/butai?action_type=1", @"page_nr=");
            var task2 = domosplusScraper.ScraperDomosplusWebsite();

            await Task.WhenAll(task1, task2);

            var allScrapedRealEstate = new List<RealEstate>();
            allScrapedRealEstate.AddRange(domosplusScraper.ScrapedRealEstate);
            allScrapedRealEstate.AddRange(kampasScraper.ScrapedRealEstate);

            var output = new OutputToJson(allScrapedRealEstate);
            output.WriteToFile();
        }
    }
}
