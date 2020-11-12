using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace WebScraper
{
    abstract class InsideAdScraper : Scraper
    {
        public override IHtmlDocument Document { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public int BuildYear { get; set; }
        public string MapLink { get; set; }
        public string MapCoords { get; set; }
        public double Price { get; set; }

        public abstract void ParseBuildingInfoLineLabelFromVal(IElement buildingInfoLine);

        public abstract string ParseMapLinkToCoords(string link);

        public abstract void DictionaryToProperties(Dictionary<string, string> dictionary);
    }
}
