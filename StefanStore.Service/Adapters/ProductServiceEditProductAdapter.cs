using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefanStore.Domain;
using StefanStoreDTO.ProductDto;

namespace StefanStore.Service.Adapters
{
    public class ProductServiceEditProductAdapter
    {
        private Product _product;

        public ProductServiceEditProductAdapter(Product product)
        {
            _product = product;
        }

        public ProductServiceEditProductResponse Fill()
        {
            var productDto = new StefanStoreDTO.ProductDto.ProductDto();

            productDto.ProductId = _product.ProductID;
            productDto.Price = _product.Price;
            productDto.Name = _product.Name;
            productDto.Description = _product.Description;
            productDto.Category = _product.Category;



            ProductServiceEditProductResponse response = new ProductServiceEditProductResponse
            {
                Product = productDto
            };

            return response;
        }
    }
}