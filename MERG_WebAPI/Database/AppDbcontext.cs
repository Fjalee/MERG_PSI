using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Microdistrict> Microdistricts { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
