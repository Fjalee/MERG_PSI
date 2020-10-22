namespace MERG_PSI
{
    class RealEstate
    {
        public string Link { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public double CalculatedPrice { get; set; }
        public double ScrapedPrice { get; set; }
        public string MapLink { get; set; }
        public string Municipality { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }

        public RealEstate(string link, double area, double pricePerSqM, int numberOfRooms, string floor, double scrapedPrice, string mapLink, string municipality, string street, int buildYear)
        {
            Link = link;
            Area = area;
            PricePerSqM = pricePerSqM;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            CalculatedPrice = pricePerSqM * area;
            ScrapedPrice = scrapedPrice;
            MapLink = mapLink;
            Municipality = municipality;
            Street = street;
            BuildYear = buildYear;
        }
        override
        public string ToString()
        {
            //return $"NT yra {Municipality}, šio namo kaina {CalculatedPrice} €, plotas {Area} m2\n";
            return $"Link|    {Link}\n" +
                   $"Area|    {Area}\n" +
                   $"PricePerSqM|    {PricePerSqM}\n" +
                   $"NumberOfRooms|    {NumberOfRooms}\n" +
                   $"Floor|    {Floor}\n" +
                   $"CalculatedPrice|    {CalculatedPrice}\n" +
                   $"ScrapedPrice|    {ScrapedPrice}\n" +
                   $"MapLink|    {MapLink}\n" +
                   $"Municipality|    {Municipality}\n" +
                   $"Street|    {Street}\n" +
                   $"BuildYear|    {BuildYear}\n" +
                   $"\n\n\n";
        }
    }
}
