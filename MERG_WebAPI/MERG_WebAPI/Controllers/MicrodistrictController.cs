using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MERG_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicrodistrictController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MicrodistrictController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<string> Get()
        {
            var microdistricts = _context.Microdistricts.Select(x => x.Name).ToList();
            return microdistricts;
        }
    }
}
