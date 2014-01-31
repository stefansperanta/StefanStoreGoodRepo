using System.Collections.Generic;

namespace StefanStoreDTO.ProductDto
{
    public class ProductServiceListProductsResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
