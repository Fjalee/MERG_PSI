namespace WebScraper
{
    public interface ILog
    {
        void Msg(string message);
        void AdInvalid(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, double latitude,
            double longitude, string municipality, string microdistrict, string street);
        void IEnCountInvalid(string link, int count, string name);
        void CantParse(string valToParse);
        void ErrorNoDocument();
        void DnContainCoords(string link);
    }
}