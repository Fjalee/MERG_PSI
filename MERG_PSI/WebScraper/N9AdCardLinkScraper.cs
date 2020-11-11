using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    class DomoplusAdCardLinkScraper : AdCardLinkScraper
    {
        public DomoplusAdCardLinkScraper(string siteUrl, string className)
        {
            _siteUrl = siteUrl;
            _classNameForAdCard = className;
        }

        override public IEnumerable<string> GetAdCardsPaths()
        {
            var adCardsPaths = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => x.ParentElement.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ParentElement.ClassList.Contains(_classNameForAdCard))
                .Select(x => ((IHtmlAnchorElement)x).PathName);

            return adCardsPaths;
        }
    }
}
