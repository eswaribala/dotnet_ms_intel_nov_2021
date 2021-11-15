using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Contexts
{
    public class InventoryServiceContext:DbContext
    {

        public InventoryServiceContext(DbContextOptions<InventoryServiceContext> options) :
            base(options){
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products {  get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Catalog>().HasMany(c => c.Products).WithOne(c => c.Catalog);
        }

    }
}
