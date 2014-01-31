using System.Linq;
using StefanStore.Domain;

namespace StefanStore.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetProductsByCategory(string categoryName);
        IQueryable<Product> GetPagedProducts(string categoryName, int pageSize, int pageNumber);
        IQueryable<string> GetAllCategories(); 
    }
}
