using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    public class DomoplusAdCardLinkScraper : AdCardLinkScraper
    {
        public DomoplusAdCardLinkScraper(string siteUrl, string className, ILog logger) : base(siteUrl, className, logger) { }

        override protected IEnumerable<string> GetAdCardsPaths()
        {
            var adCardsPaths = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => x.ParentElement.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ParentElement.ClassList.Contains(ClassNameForAdCard))
                .Select(x => ((IHtmlAnchorElement)x).PathName);

            return adCardsPaths;
        }
    }
}
