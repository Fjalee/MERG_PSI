using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public class DomosplusScraper : SiteScraper
    {
        public DomosplusScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString) : base(myUI, websiteLink, subdirectory, pageString) { }

        public async Task ScraperDomosplusWebsite()
        {
            var websitePage = 1;
            while (!ReachedPageNoAds)
            //while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = WebsiteLink + Subdirectory + "&" + PageString + websitePage.ToString() + "&slist = 100584040";
                base.RaiseScrapingDomainEvent(linkWithPage);

                var adCardLinkScraper = new DomoplusAdCardLinkScraper(WebsiteLink, "item");
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();

                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var ias = new DomosplusInsideAdScraper(link);
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        if (IsAdHasAllNeededData(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.MapCoords))
                        {
                            ScrapedRealEstate.Add(new RealEstate(link: link, area: ias.Area, pricePerSqM: ias.PricePerSqM, numberOfRooms: ias.NumberOfRooms,
                            floor: ias.Floor, scrapedPrice: ias.Price, mapLink: ias.MapLink, buildYear: ias.BuildYear, mapCoords: ias.MapCoords, image: ias.Image)); //fix Municipality, Street instead of "", ""
                        }

                        else
                        {
                            MyLog.AdInvalid(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, "", "", ias.MapCoords); //fix Municipality, Street instead of "", ""
                        }
                    }
                    websitePage++;
                }
                else { ReachedPageNoAds = true; }
            }
        }
    }
}
