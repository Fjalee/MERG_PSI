using System.Collections.Generic;
using System.Threading;
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

        public async void ScrapeAllWebsites()
        {
            var kampasScraper = new KampasScraper(_myUI, @"https://www.kampas.lt", @"/butai", @"page=");
            var thread1 = new Thread(kampasScraper.ScrapeKampasWebsite);
            thread1.Start();

            var domosplusScraper = new DomosplusScraper(_myUI, @"https://domoplius.lt", @"/skelbimai/butai?action_type=1", @"page_nr=");
            var thread2 = new Thread(new ThreadStart(domosplusScraper.ScraperDomosplusWebsite));
            thread2.Start();

            thread1.Join();
            thread2.Join();
            var allScrapedRealEstate = new List<RealEstate>();
            allScrapedRealEstate.AddRange(domosplusScraper.ScrapedRealEstate);
            allScrapedRealEstate.AddRange(kampasScraper.ScrapedRealEstate);

            var output = new OutputToJson(allScrapedRealEstate);
            output.WriteToFile();
        }
    }
}
