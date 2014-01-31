using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefanStore.Domain;
using StefanStoreDTO.ProductDto;

namespace StefanStore.Service.Adapters
{
    public class CartServiceAdapter
    {
        private Product _product;

        public CartServiceAdapter(Product product)
        {
            _product = product;
        }

        public ProductDto Fill()
        {
            StefanStoreDTO.ProductDto.ProductDto productDto = new StefanStoreDTO.ProductDto.ProductDto();
            productDto.ProductId = _product.ProductID;
            productDto.Price = _product.Price;
            productDto.Name = _product.Name;
            productDto.Description = _product.Description;
            productDto.Category = _product.Category;

            return productDto;
        }
    }
}
