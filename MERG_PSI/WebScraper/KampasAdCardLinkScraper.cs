using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebScraper
{
    class KampasAdCardLinkScraper : AdCardLinkScraper
    {
        public KampasAdCardLinkScraper(string siteUrl, string className) : base(siteUrl, className) { }
        override protected IEnumerable<string> GetAdCardsPaths()
        {
            var adCardsPaths = Document.All
                .Where(x => x.LocalName == "a")
                .Where(x => x.ParentElement.LocalName == "div")
                .Where(x => x.ParentElement.ClassList.Contains(ClassNameForAdCard))
                .Select(x => ((IHtmlAnchorElement)x).PathName);

            return adCardsPaths;
        }
    }
}