using Common;
using Dapper;
using Database;
using MERG_BackEnd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MERG_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IInspection _inspection;
        private readonly AppDbContext _dbContext;

        public RealEstateController(IInspection inspection, AppDbContext dbContext)
        {
            _inspection = inspection;
            _dbContext = dbContext;
        }

        //[HttpGet]
        //public List<RealEstateModel> Get()
        //{
        //    return _dbContext.RealEstates.Select(x => (RealEstateModel)x).ToList();
        //}

        [HttpGet]
        public string Get()
        {

            //Server = myServerAddress; Port = 1234; Database = myDataBase; Uid = myUsername; Pwd = myPassword;
            //var conString = "Source=tcp:mergpsi.database.windows.net,1433;Initial Catalog=Db;User Id=mergAdmin@mergpsi;Password=!132435@qwer#M";
            var conString = "Data Source=tcp:mergpsi.database.windows.net,1433;Initial Catalog=Db;User Id=mergAdmin@mergpsi;Password=!132435@qwer#M";

            using (var connection = new SqlConnection(conString))
            {
                var temp = connection.Query<dynamic>(@"SELECT * FROM RealEstate");
                //connection.Execute("truncate table RealEstate")

                //temp = await connection.QueryAsync<RealEstate>(sql);
                //var temp = await connection.QueryAsync<Database.Entities.RealEstate>(sql);

                var x = "";
                var y = "";
            };
            //ConfigureManager.ConnectionStrings["DefaultConnection"].ConnectionString
            //ConfigurationManager.AppSettings.Get("DefaultConnection");


            var list = _dbContext.RealEstates.Select(x => x).ToList();
            var i = 0;
            foreach (var item in list)
            {
                i++;
            }

            return "afasdasdasda";
        }

        [HttpGet("{municipality}/{microdistrict}/{street}/{isPriceFrom}/{priceFrom}/{isPriceTo}/{priceTo}/{isAreaFrom}/{areaFrom}/{isAreaTo}/{areaTo}/{isBuildYearFrom}/{buildYearFrom}/{isBuildYearTo}/{buildYearTo}/{isNumberOfRoomsFrom}/{numberOfRoomsFrom}/{isNumberOfRoomsTo}/{numberOfRoomsTo}/{isPricePerSqMFrom}/{pricePerSqMFrom}/{isPricePerSqMTo}/{pricePerSqMTo}/{noInfoBuildYear}/{noInfoRoomNumber}")]
        public List<RealEstateModel> Get(string municipality, string microdistrict, string street,
            bool isPriceFrom, int priceFrom, bool isPriceTo, int priceTo,
            bool isAreaFrom, int areaFrom, bool isAreaTo, int areaTo,
            bool isBuildYearFrom, int buildYearFrom, bool isBuildYearTo, int buildYearTo,
            bool isNumberOfRoomsFrom, int numberOfRoomsFrom, bool isNumberOfRoomsTo, int numberOfRoomsTo,
            bool isPricePerSqMFrom, int pricePerSqMFrom, bool isPricePerSqMTo, int pricePerSqMTo,
            bool noInfoBuildYear, bool noInfoRoomNumber)
        {
            var _listOfRealEstates = _dbContext.RealEstates.Select(x => (RealEstateModel)x).ToList();

            municipality = municipality == "noMunicipality" ? "" : municipality;
            microdistrict = microdistrict == "noMicrodistrict" ? "" : microdistrict;
            street = street == "noStreet" ? "" : street;

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

        [HttpPut]
        public void Put([FromBody] List<Database.Entities.RealEstate> listOfRealEstate)
        {
            //System.Data.Entity.DbContext
            //_dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [RealEstate]");
            listOfRealEstate.ForEach(x => _dbContext.Add(x));
            _dbContext.SaveChanges();
        }
    }
}
