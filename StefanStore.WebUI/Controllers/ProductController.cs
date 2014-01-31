using System.Web.Mvc;
using StefanStore.Service;
using StefanStoreDTO.ProductDto;

namespace StefanStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public int PageSize = 4;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        public ViewResult ListProducts(string category, int page = 1)
        {
            var request = new ProductServiceListProductsRequest(category, PageSize, page);

            ProductServiceListProductsResponse response = _productService.ListProducts(request);

            return View(response);
        }
    }
}