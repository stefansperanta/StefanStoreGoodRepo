using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StefanStore.Repository.Abstract.UnitOfWork;
using StefanStore.Service.Adapters;
using StefanStoreDTO.ProductDto;
using Product = StefanStore.Domain.Product;

namespace StefanStore.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public ProductServiceListProductsResponse ListProducts(ProductServiceListProductsRequest request)
        {
            int totalItems = _unitOfWork.Products.GetAll().Where(p => request.Category == null || p.Category == request.Category).Count();

            IEnumerable<Product> products = _unitOfWork.Products.GetAll().OrderBy(p => p.ProductID).
             Where(p => request.Category == null || p.Category == request.Category)
             .Skip((request.PageNumber - 1) * request.PageSize)
             .Take(request.PageSize);

            ProductServiceListProductsAdapter productAdapter = new ProductServiceListProductsAdapter(products, request, totalItems);

            ProductServiceListProductsResponse response = productAdapter.Fill();

            return response;
        }
    }
}