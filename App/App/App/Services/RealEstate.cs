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
        public List<RealEstateModel> MyData; 
        public RealEstate()
        {
            MyData = new List<RealEstateModel>
            {
                new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-klaipedoje-miskas-igulos-g-3-4-kambariu-butas-10-15-min-pesciomis-nuo-604880", Area = 100, BuildYear = 1955, Floor = "1", Latitude = 54.6872, Longitude = 25.2797, MapLink = "linkas", Municipality = "Vilnius", NumberOfRooms = 2, Price = 253514, PricePerSqM = 2500, Street = "Konarskio" ,Microdistrict = "Baltupiai",Image="https://cf.bstatic.com/images/hotel/max1024x768/255/255830738.jpg"},
                new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-vilniuje-senamiestis-subaciaus-g-s-k-u-b-i-a-i-parduodamas-146-kvm-butas-605316", Area = 9, BuildYear = 1955, Floor = "1", Latitude = 55.0788554, Longitude = 24.2493011, MapLink = "linkas", Municipality = "Jonava", NumberOfRooms = 2, Price = 250000, PricePerSqM = 2500, Street = "Kernagio" ,Microdistrict = "Šilainiai",Image="https://images.adsttc.com/media/images/5be9/fd5c/08a5/e5a5/8c00/008f/slideshow/CARLES_FAUS_ARQUITECTURA_-_CARMEN_HOUSE_(2).jpg"},
                new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-vilniuje-senamiestis-saltiniu-g-parduodamas-butas-senamiestyje-saltiniu-605300", Area = 100, BuildYear = 1955, Floor = "1", Latitude = 55.2548451, Longitude = 24.7438185,  MapLink = "linkas", Municipality = "Ukmergė", NumberOfRooms = 2, Price = 69000, PricePerSqM = 2500, Street = "Vytauto",Image="https://q4g9y5a8.rocketcdn.me/wp-content/uploads/2020/02/home-banner-2020-02-min.jpg",Microdistrict="Troškūnai" },
                 new RealEstateModel { Link = "https://www.kampas.lt/skelbimai/butas-palangoje-vytauto-g-parduodamas-2-kambariu-butas-vytauto-g-palangoje-adresas-613219", Area = 42, BuildYear = 0, Floor = "1/3", Latitude =55.9189917, Longitude = 21.0670757,  MapLink = "https://maps.google.com/maps?q=55.9189917,21.0670757", Municipality = "Palangos m. sav", NumberOfRooms =2 , Price =70000 , PricePerSqM = 1666, Street = "Vytauto g.",Image="https://kampas-company-images.s3.eu-central-1.amazonaws.com/images/2020/11/17/28298297.jpg",Microdistrict="Palanga" }
            };
            //var des = new DeserializationFromJson();
            //var data = des.Data;

        }
        public async Task<List<RealEstateModel>> GetRealEstates()
        {
            return await Task.FromResult(MyData);
        }

    }
}
