using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebScraper
{
    public class AllScrapers
    {
        private readonly KampasScraper _kampasScraper;
        private readonly DomosplusScraper _domosplusScraper;
        private readonly OutputToJson _output;

        public AllScrapers(KampasScraper kampasScraper, DomosplusScraper domosplusScraper, OutputToJson output)
        {
            _kampasScraper = kampasScraper;
            _domosplusScraper = domosplusScraper;
            _output = output;
        }

        public async Task ScrapeAllWebsites(Form1 myUI)
        {
            var task1 = _kampasScraper.ScrapeWebsite(myUI);
            var task2 = _domosplusScraper.ScrapeWebsite(myUI);

            await Task.WhenAll(task1, task2);

            var allScrapedRealEstate = new List<RealEstate>();
            allScrapedRealEstate.AddRange(_domosplusScraper.ScrapedRealEstate);
            allScrapedRealEstate.AddRange(_kampasScraper.ScrapedRealEstate);

            _output.WriteToFile(allScrapedRealEstate);
        }
    }
}