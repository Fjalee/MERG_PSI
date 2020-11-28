using Autofac;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebScraper
{
    public class AllScrapers
    {
        private readonly Form1 _myUI;
        private readonly ILog _logger;
        public AllScrapers(Form1 myUI, ILog logger)
        {
            _logger = logger;
            _myUI = myUI;
        }

        public async Task ScrapeAllWebsites()
        {
            var kampasScraper = new KampasScraper(_myUI, @"https://www.kampas.lt", @"/butai", @"page=", "?", _logger);
            var task1 = kampasScraper.ScrapeWebsite();

            var domosplusScraper = new DomosplusScraper(_myUI, @"https://domoplius.lt", @"/skelbimai/butai?action_type=1", @"page_nr=", "&", _logger);
            var task2 = domosplusScraper.ScrapeWebsite();

            await Task.WhenAll(task1, task2);

            var allScrapedRealEstate = new List<RealEstate>();
            allScrapedRealEstate.AddRange(domosplusScraper.ScrapedRealEstate);
            allScrapedRealEstate.AddRange(kampasScraper.ScrapedRealEstate);

            var output = new OutputToJson(allScrapedRealEstate);
            output.WriteToFile();
        }
    }
}
