namespace WebScraper
{
    public class GoogleGeoCodeResponse
    {
        public string Status { get; set; }
        public Results[] Results { get; set; }
    }

    public class Results
    {
        public string Formatted_address { get; set; }
        public Geometry Geometry { get; set; }
        public string[] Types { get; set; }
        public Address_component[] Address_components { get; set; }
    }

    public class Geometry
    {
        public string Location_type { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Address_component
    {
        public string Long_name { get; set; }
        public string Short_name { get; set; }
        public string[] Types { get; set; }
    }
}
