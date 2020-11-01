namespace App
{
    class RealEstate
    {
        public string Link { get; set; }
        public double Area { get; set; }
        public double PricePerSqM { get; set; }
        public int NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public double Price { get; set; }
        public string MapLink { get; set; }
        public string Municipality { get; set; }
        public string Street { get; set; }
        public int BuildYear { get; set; }
        public string MapCoords { get; set; }

        override
        public string ToString()
        {
            return $"\n Kaina: {Price} €\n Nuoroda: {Link}\n Kaina/m²: {PricePerSqM} €/m²\n Plotas: {Area} m²\n Kambariai: {NumberOfRooms}\n";
        }
    }
}