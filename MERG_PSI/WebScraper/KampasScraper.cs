using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public class KampasScraper : SiteScraper
    {
        public KampasScraper(Form1 myUI, string websiteLink, string subdirectory, string pageString, string symbol) : base(myUI, websiteLink, subdirectory, pageString, symbol) { }

        protected override AdCardLinkScraper InstanciateAdCardLinkScraperObject()
        {
            return new KampasAdCardLinkScraper(WebsiteLink, "k-ad-card-wide");
        }

        protected override InsideAdScraper InstanciateInsideAdScraperObject(string link)
        {
            return new KampasInsideAdScraper(link);
        }
    }
}
