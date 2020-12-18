using Database;
using Database.Entities;
using MERG_BackEnd;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MERG_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MunicipalityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Municipality> Get()
        {
            var municipalities = _context.Municipalities.ToList();
            return municipalities;
        }

    }
}
