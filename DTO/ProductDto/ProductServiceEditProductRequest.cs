using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefanStoreDTO.ProductDto
{
    public class ProductServiceEditProductRequest
    {
        private int _productId;

        public ProductServiceEditProductRequest(int productId)
        {
            ProductId = productId;
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
    }
}
