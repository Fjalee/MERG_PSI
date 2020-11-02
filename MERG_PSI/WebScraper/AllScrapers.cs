using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var kampasScraper = new KampasScraper(_myUI);
            await kampasScraper.ScrapeKampasWebsite();

            var output = new OutputToJson(kampasScraper.ScrapedRealEstate);
            output.WriteToFile();
        }
    }
}
