using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MERG_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StreetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<string> Get()
        {
            var streets = _context.Streets.Select(x => x.Name).ToList();
            return streets;
        }
    }
}
