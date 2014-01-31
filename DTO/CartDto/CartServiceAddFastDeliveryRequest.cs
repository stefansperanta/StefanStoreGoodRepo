using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefanStoreDTO.CartDto
{
    public class CartServiceAddFastDeliveryRequest
    {
        private bool _addFastDelivery;
        private CartDto _cart;

        public CartServiceAddFastDeliveryRequest(CartDto cart,bool addFastDelivery)
        {
            AddFastDelivery = addFastDelivery;
            Cart = cart;
        }

        public bool AddFastDelivery
        {
            get { return _addFastDelivery; }
            set { _addFastDelivery = value; }
        }

        public CartDto Cart
        {
            get { return _cart; }
            set { _cart = value; }
        }
    }
}
