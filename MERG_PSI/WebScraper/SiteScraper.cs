namespace WebScraper
{
    public abstract class SiteScraper
    {
        public string _websiteLink { get; set; }
        public string _subdirectory { get; set; }
        public string _pageQueryString { get; set; }

        public bool IsAdHasAllNeededData(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string mapCoords)
        {
            var calculatedPrice = pricePerSqM * area;
            if (
                //fix put area and priceerarea

                mapCoords == "" ||
                link == "" ||
                mapLink == "" ||
                numberOfRooms == 0 ||
                (calculatedPrice == 0 && scrapedPrice == 0) ||
                !IsValuesClose(calculatedPrice, scrapedPrice, 1000)
                /*Municipality == /*fix to be implemented*/
                /*Street == /*fix to be implemented*/)
            {
                return false;
            }
            else { return true; }
        }

        public bool IsValuesClose(double value1, double value2, int roundErr)
        {
            var diff = value1 - value2;
            if ((diff < roundErr && diff >= 0) || (diff <= 0 && diff > -roundErr))
            {
                return true;
            }
            else { return false; }
        }
    }
}
