using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefanStoreDTO.CartDto;

namespace StefanStore.Service
{
    public interface ICartService
    {
        void AddProductToCart(CartServiceAddProductToCartRequest request);
        void RemoveProductFromCart(CartServiceRemoveProductToCartRequest request);
        void AddFastDelivery(CartServiceAddFastDeliveryRequest request);
    }
}
