using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefanStoreDTO.CartDto
{
    public class CartServiceRemoveProductToCartRequest
    {
        private CartDto _cart;
        private int _productId;

        public CartServiceRemoveProductToCartRequest(CartDto cart, int productId)
        {
            Cart = cart;
            ProductId = productId;
        }

        public CartDto Cart
        {
            get { return _cart; }
            set { _cart = value; }
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
    }
}
