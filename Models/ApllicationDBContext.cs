using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Models
{
    public class ApllicationDBContext: DbContext
    {
        public ApllicationDBContext():base()
        {

        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet <OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K4R66GP;Database=EcommerceProject;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=False");
        }
    }
    

}
