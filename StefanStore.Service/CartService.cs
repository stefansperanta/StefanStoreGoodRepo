using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefanStore.Domain;
using StefanStore.Repository.Abstract.UnitOfWork;
using StefanStore.Service.Adapters;
using StefanStoreDTO.CartDto;
using StefanStoreDTO.ProductDto;

namespace StefanStore.Service
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProductToCart(CartServiceAddProductToCartRequest request)
        {
            Product product = _unitOfWork.Products.GetAll().FirstOrDefault(p => p.ProductID == request.ProductId);

            CartServiceAdapter adapter = new CartServiceAdapter(product);

            request.Cart.AddItem(adapter.Fill(), 1);
        }

        public void RemoveProductFromCart(CartServiceRemoveProductToCartRequest request)
        {
            Product product = _unitOfWork.Products.GetAll().FirstOrDefault(p => p.ProductID == request.ProductId);

            CartServiceAdapter adapter = new CartServiceAdapter(product);

            request.Cart.RemoveLine(adapter.Fill());
        }


        public void AddFastDelivery(CartServiceAddFastDeliveryRequest request)
        {
            if (request.AddFastDelivery)
                request.Cart.ExtraPrice = (double)request.Cart.ComputeTotalValue() * 0.05;
            else request.Cart.ExtraPrice = 0;
        }
    }
}
