using Microsoft.EntityFrameworkCore;

namespace WeeklyMiniProject_w30_31
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductsDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Laptop>();
            builder.Entity<MobilePhone>();

            base.OnModelCreating(builder);
        }
    }
}