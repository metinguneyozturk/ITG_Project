

using Microsoft.EntityFrameworkCore;

namespace ITG_Project.Models
{

    
     public class DataContext:DbContext
     {

        public DbSet<ProductModel>? Products{get;set;}
        public DbSet<BillModel>? Bills{get;set;}
        public DbSet<RetailerModel>? Retailers{get;set;}
        public DbSet<SupplierModel>? Suppliers{get;set;}

        public DbSet<Blog>? Blogs{get;set;}
        
        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
            UseNpgsql(
                "Host=localhost;Database=ITG_Project;Username=remote;Password=1234");
        
        }


     }
}
