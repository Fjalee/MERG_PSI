using Database;
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
        public List<string> Get()
        {
            var municipalities = _context.Municipalities.Select(x => x.Name).ToList();
            return municipalities;
        }
    }
}
