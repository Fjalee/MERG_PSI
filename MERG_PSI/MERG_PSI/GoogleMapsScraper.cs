using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERG_PSI
{
    class GoogleMapsScraper : Scraper
    {
        public override IHtmlDocument Document { get; set ; }
        private string _link;
        public string Municipality { get; set; }
        public string Street { get; set; }

        public GoogleMapsScraper(string link)
        {
            _link = link;
        }

        public override void Scrape()
        {
            ScrapeAdress();
        }

        private void ScrapeAdress()
        {
            if (Document == null)
            {
                MyLog.ErrorNoDocument();
            }

            //var sidebarHtml = GetSideBarHtml();
        }

        /*private IEnumerable<IElement> GetSideBarHtml()
        {
            IEnumerable<IElement> sidebarHtml = null;

            sidebarHtml = Document.All.Where(x =>
                x.LocalName == "" &&
                x.ParentElement.LocalName == "" &&
                x.ParentElement.ClassList.Contains("section - hero - header - title - title"));

            return sidebarHtml;
        }*/
    }
}
