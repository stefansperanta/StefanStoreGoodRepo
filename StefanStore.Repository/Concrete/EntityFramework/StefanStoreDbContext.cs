using System.Data.Entity;
using StefanStore.Domain;

namespace StefanStore.Repository.Concrete
{
    public class StefanStoreDbContext : DbContext
    {
        public StefanStoreDbContext()
         //this is the connection string name
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
