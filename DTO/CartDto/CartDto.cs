using System;
using System.Collections.Generic;
using System.Linq;


namespace StefanStoreDTO.CartDto
{
    public class CartDto
    {
        private List<CartLineDto> lineCollection = new List<CartLineDto>();
        private double _extraPrice = 0;

        public IEnumerable<CartLineDto> Lines
        {
            get { return lineCollection; }
        }

        public double ExtraPrice
        {
            get { return _extraPrice; }
            set { _extraPrice = value; }
        }

        public void AddItem(ProductDto.ProductDto product, int quantity)
        {
            CartLineDto line = lineCollection
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLineDto
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductDto.ProductDto product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public double ComputeTotalValue()
        {
            return (double)lineCollection.Sum(e => e.Product.Price * e.Quantity) + ExtraPrice;

        }
        public void Clear()
        {
            lineCollection.Clear();
            ExtraPrice = 0;
        }
    }
}
