using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Text;

namespace WebScraper
{
    public class AllScrapers
    {
        private readonly KampasScraper _kampasScraper;
        private readonly DomosplusScraper _domosplusScraper;
        private readonly IOutput _output;

        public AllScrapers(KampasScraper kampasScraper, DomosplusScraper domosplusScraper, IOutput output)
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


            var jsonToOutput = JsonConvert.SerializeObject(allScrapedRealEstate);
            await _output.DoOutput(jsonToOutput);
        }
    }
}