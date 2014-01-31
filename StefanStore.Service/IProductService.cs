using System.Collections.Generic;
using StefanStoreDTO.ProductDto;

namespace StefanStore.Service
{
    public interface IProductService
    {
        ProductServiceListProductsResponse ListProducts(ProductServiceListProductsRequest request);
    }
}
