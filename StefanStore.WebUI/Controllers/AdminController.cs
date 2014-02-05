using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StefanStore.Service;
using StefanStoreDTO.ProductDto;

namespace StefanStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductService _productService;

        public ViewResult ListProducts(int page = 1)
        {
            var request = new ProductServiceListProductsRequest(null, 4, page);

            ProductServiceListProductsResponse response = _productService.ListProducts(request);

            return View(response);
        }

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult EditProduct(int productId)
        {
            var request = new ProductServiceEditProductRequest(productId);

            ProductServiceEditProductResponse response = _productService.EditProduct(request);

            return View(response);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductServiceEditProductResponse response)
        {
            if (ModelState.IsValid)
            {
                _productService.SaveProduct(response);
                TempData["message"] = string.Format("{0} has been saved", response.Product.Name);
                return RedirectToAction("ListProducts");
            }
            else
            {
                return View(response);
            }
        }

        public ViewResult CreateProduct()
        {
            return View("EditProduct", new ProductServiceEditProductResponse { Product = new ProductDto() });
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductServiceEditProductResponse response)
        {
            if (ModelState.IsValid)
            {
                _productService.SaveProduct(response);
                TempData["message"] = string.Format("{0} has been saved", response.Product.Name);
                return RedirectToAction("ListProducts");
            }
            else
            {
                return View("EditProduct", response);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            string productName = _productService.DeleteProduct(productId);
            TempData["message"] = string.Format("{0} was deleted", productName);
            return RedirectToAction("ListProducts");
        }

    }
}
