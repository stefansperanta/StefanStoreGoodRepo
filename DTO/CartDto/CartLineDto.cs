
namespace StefanStoreDTO.CartDto
{
    public class CartLineDto
    {
        public ProductDto.ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
