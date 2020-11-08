using App.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class RealEstate : IRealEstate
    {
        public List<RealEstateModel> _myData; 
        public RealEstate()
        {
            _myData = new List<RealEstateModel>
            {
                new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-klaipedoje-miskas-igulos-g-3-4-kambariu-butas-10-15-min-pesciomis-nuo-604880", Area = 100, BuildYear = 1955, Floor = "1", Latitude = 20.1235, Longtitude = 30.3146, MapCoords = "20.1235,30.3146", MapLink = "linkas", Municipality = "Vilnius", NumberOfRooms = 2, Price = 253514, PricePerSqM = 2500, Street = "gatve" ,ImageUrl="https://cf.bstatic.com/images/hotel/max1024x768/255/255830738.jpg"},
                new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-vilniuje-senamiestis-subaciaus-g-s-k-u-b-i-a-i-parduodamas-146-kvm-butas-605316", Area = 100, BuildYear = 1955, Floor = "1", Latitude = 20.1235, Longtitude = 30.3146, MapCoords = "20.1235,30.3146", MapLink = "linkas", Municipality = "Kaunas", NumberOfRooms = 2, Price = 250000, PricePerSqM = 2500, Street = "gatve" ,ImageUrl="https://images.adsttc.com/media/images/5be9/fd5c/08a5/e5a5/8c00/008f/slideshow/CARLES_FAUS_ARQUITECTURA_-_CARMEN_HOUSE_(2).jpg"},
                new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-vilniuje-senamiestis-saltiniu-g-parduodamas-butas-senamiestyje-saltiniu-605300", Area = 100, BuildYear = 1955, Floor = "1", Latitude = 20.1235, Longtitude = 30.3146, MapCoords = "54.6748048,25.3093487", MapLink = "linkas", Municipality = "Ukmergė", NumberOfRooms = 2, Price = 69000, PricePerSqM = 2500, Street = "gatve",ImageUrl="https://q4g9y5a8.rocketcdn.me/wp-content/uploads/2020/02/home-banner-2020-02-min.jpg" }
            };

        }
        public async Task<List<RealEstateModel>> GetRealEstates()
        {
            return await Task.FromResult(_myData);
        }
    }
}
