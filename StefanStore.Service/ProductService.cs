using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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


        public ProductServiceEditProductResponse EditProduct(ProductServiceEditProductRequest request)
        {
            Product product = _unitOfWork.Products.GetAll().FirstOrDefault(p => p.ProductID == request.ProductId);

            ProductServiceEditProductAdapter productAdapter = new ProductServiceEditProductAdapter(product);

            ProductServiceEditProductResponse response = productAdapter.Fill();

            return response;
        }

        public void SaveProduct(ProductServiceEditProductResponse request)
        {
            ProductServiceSaveProductAdapter productAdapter = new ProductServiceSaveProductAdapter(request.Product);

            if (request.Product.ProductId > 0)
                _unitOfWork.Products.Update(productAdapter.Fill());
            else _unitOfWork.Products.Add(productAdapter.Fill());
            _unitOfWork.Commit();
        }


        public string DeleteProduct(int productId)
        {
            Product product = _unitOfWork.Products.GetAll().FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                string name = product.Name;
                _unitOfWork.Products.Delete(product);
                _unitOfWork.Commit();
                return name;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}