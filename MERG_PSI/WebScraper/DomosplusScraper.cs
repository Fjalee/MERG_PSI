using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public class DomosplusScraper : SiteScraper
    {
        public DomosplusScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString, string symbol) : base(myUI, websiteLink, subdirectory, pageString, symbol) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject()
        {
            return new DomoplusAdCardLinkScraper(WebsiteLink, "item");
        }

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link)
        {
            return new DomosplusInsideAdScraper(link);
        }
    }
}
