using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Microdistrict> Microdistricts { get; set; }
        public DbSet<Street> Streets { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Microdistrict>(entity =>
            {
                entity.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsRequired();
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
