using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MERG_BackEnd;

namespace MERG_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        //dont delete comment below, its for testing
        //https://localhost:44376/api/RealEstate/SampleMunicipality3/SampleMicrodistrict3/SampleStreet3/false/0/false/0/false/0/false/0/false/0/false/0/false/0/false/0/false/0/false/0/false/false

        private readonly List<RealEstate> _listOfRealEstates;   //fix, this should be deleted when data base is created
        private readonly IInspection _inspection;

        public RealEstateController(IInspection inspection)
        {
            _inspection = inspection;
            _listOfRealEstates = new DummyDB().ListOfRealEstates;
        }

        [HttpGet("{municipality}/{microdistrict}/{street}/{isPriceFrom}/{priceFrom}/{isPriceTo}/{priceTo}/{isAreaFrom}/{areaFrom}/{isAreaTo}/{areaTo}/{isBuildYearFrom}/{buildYearFrom}/{isBuildYearTo}/{buildYearTo}/{isNumberOfRoomsFrom}/{numberOfRoomsFrom}/{isNumberOfRoomsTo}/{numberOfRoomsTo}/{isPricePerSqMFrom}/{pricePerSqMFrom}/{isPricePerSqMTo}/{pricePerSqMTo}/{noInfoBuildYear}/{noInfoRoomNumber}")]
        public List<RealEstate> Get(string municipality, string microdistrict, string street,
            bool isPriceFrom, int priceFrom, bool isPriceTo, int priceTo,
            bool isAreaFrom, int areaFrom, bool isAreaTo, int areaTo,
            bool isBuildYearFrom, int buildYearFrom, bool isBuildYearTo, int buildYearTo,
            bool isNumberOfRoomsFrom, int numberOfRoomsFrom, bool isNumberOfRoomsTo, int numberOfRoomsTo,
            bool isPricePerSqMFrom, int pricePerSqMFrom, bool isPricePerSqMTo, int pricePerSqMTo,
            bool noInfoBuildYear, bool noInfoRoomNumber)
        {

            var filter = new FiltersValue(municipality: municipality, microdistrict: microdistrict, street: street,
               priceFrom: new Tuple<bool, int>(isPriceFrom, priceFrom),
               priceTo: new Tuple<bool, int>(isPriceTo, priceTo),
               areaFrom: new Tuple<bool, int>(isAreaFrom, areaFrom),
               areaTo: new Tuple<bool, int>(isAreaTo, areaTo),
               buildYearFrom: new Tuple<bool, int>(isBuildYearFrom, buildYearFrom),
               buildYearTo: new Tuple<bool, int>(isBuildYearTo, buildYearTo),
               numberOfRoomsFrom: new Tuple<bool, int>(isNumberOfRoomsFrom, numberOfRoomsFrom),
               numberOfRoomsTo: new Tuple<bool, int>(isNumberOfRoomsTo, numberOfRoomsTo),
               pricePerSqMFrom: new Tuple<bool, int>(isPricePerSqMFrom, pricePerSqMFrom),
               pricePerSqMTo: new Tuple<bool, int>(isPricePerSqMTo, pricePerSqMTo),
               noBuildYearInfo: noInfoBuildYear, noNumberOfRoomsInfo: noInfoRoomNumber);

            try
            {
                return _inspection.GetFilteredListOFRealEstate(_listOfRealEstates, filter);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
