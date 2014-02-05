using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefanStore.Domain;
using StefanStoreDTO.ProductDto;

namespace StefanStore.Service.Adapters
{
    public class ProductServiceSaveProductAdapter
    {
        private ProductDto _productDto;

        public ProductServiceSaveProductAdapter(ProductDto productDto)
        {
            _productDto = productDto;
        }

        public Product Fill()
        {
            var product = new Product();

            product.ProductID = _productDto.ProductId;
            product.Price = _productDto.Price;
            product.Name = _productDto.Name;
            product.Description = _productDto.Description;
            product.Category = _productDto.Category;

            return product;
        }
    }
}