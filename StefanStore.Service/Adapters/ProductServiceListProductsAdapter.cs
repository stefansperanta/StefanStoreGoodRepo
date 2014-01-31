using System.Collections.Generic;
using StefanStore.Domain;
using StefanStoreDTO.ProductDto;

namespace StefanStore.Service.Adapters
{
    public class ProductServiceListProductsAdapter
    {
        private IEnumerable<Product> _products;
        private ProductServiceListProductsRequest _request;
        private int _totalItems;

        public ProductServiceListProductsAdapter(IEnumerable<Product> products, ProductServiceListProductsRequest request,int totalItems)
        {
            _products = products;
            _request = request;
            _totalItems = totalItems;
        }

        public ProductServiceListProductsResponse Fill()
        {
            var productsDto = new List<StefanStoreDTO.ProductDto.ProductDto>();

            foreach (var product in _products)
            {
                StefanStoreDTO.ProductDto.ProductDto productDto=new StefanStoreDTO.ProductDto.ProductDto();
                productDto.ProductId=product.ProductID;
                productDto.Price = product.Price;
                productDto.Name = product.Name;
                productDto.Description = product.Description;
                productDto.Category = product.Category;

                productsDto.Add(productDto);
            }

            ProductServiceListProductsResponse response = new ProductServiceListProductsResponse
            {
                CurrentCategory = _request.Category,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = _request.PageNumber,
                    ItemsPerPage = _request.PageSize,
                    TotalItems = _totalItems
                },
                Products = productsDto
            };

            return response;
        }
    }
}
