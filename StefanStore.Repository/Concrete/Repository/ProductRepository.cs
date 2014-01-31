using System.Data.Entity;
using System.Linq;
using StefanStore.Domain;
using StefanStore.Repository.Abstract;

namespace StefanStore.Repository.Concrete.Repository
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }

        public IQueryable<Product> GetPagedProducts(string categoryName, int pageSize, int pageNumber)
        {
            return GetAll().OrderBy(p => p.ProductID)
                .Where(p => categoryName == null || p.Category == categoryName).Skip((pageNumber - 1) * pageSize);
        }

        public IQueryable<Product> GetProductsByCategory(string categoryName)
        {
            return GetAll().Where(p => p.Category == categoryName);
        }


        public IQueryable<string> GetAllCategories()
        {
            return GetAll().Select(x => x.Category).Distinct().OrderBy(x => x);
        }
    }
}