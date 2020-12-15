using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebScraper
{
    public class AllScrapers
    {
        //private readonly Form1 _myUI;
        private readonly KampasScraper _kampasScraper;
        private readonly DomosplusScraper _domosplusScraper;
        private readonly OutputToJson _output;
        private readonly List<RealEstate> _allScrapedRealEstate;

        public AllScrapers(/*Form1 myUI, */KampasScraper kampasScraper, DomosplusScraper domosplusScraper, OutputToJson output, List<RealEstate> allScrapedRealEstate)
        {
            //_myUI = myUI;
            _kampasScraper = kampasScraper;
            _domosplusScraper = domosplusScraper;
            _output = output;
            _allScrapedRealEstate = allScrapedRealEstate;
        }

        public async Task ScrapeAllWebsites(Form1 myUI)
        {
            var task1 = _kampasScraper.ScrapeWebsite(myUI);
            var task2 = _domosplusScraper.ScrapeWebsite(myUI);

            await Task.WhenAll(task1, task2);

            //var allScrapedRealEstate = new List<RealEstate>();
            _allScrapedRealEstate.AddRange(_domosplusScraper.ScrapedRealEstate);
            _allScrapedRealEstate.AddRange(_kampasScraper.ScrapedRealEstate);

            //var output = new OutputToJson();
            _output.WriteToFile(_allScrapedRealEstate);
        }
    }
}