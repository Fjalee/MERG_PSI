using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

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

            await Temp(allScrapedRealEstate);
            //_output.WriteToFile(allScrapedRealEstate);
        }

        private async Task Temp(List<RealEstate> listOfRealEstates)
        {
            var _webApiLink = ConfigurationManager.AppSettings.Get("WEB_API_LINK");
            var _realEstateContrUri = ConfigurationManager.AppSettings.Get("REALESTATE_CONTR_URI");
            
            var uri = new Uri($"{_webApiLink}/{_realEstateContrUri}");

            var serializedList = JsonConvert.SerializeObject(listOfRealEstates);
            var content = new StringContent(serializedList);

            var _httpClient = new HttpClient();
            var temp = await _httpClient.PutAsync(uri, content);
        }
    }
}