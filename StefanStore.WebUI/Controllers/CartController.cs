using System.IO;
using System.Linq;
using System.Web.Mvc;
using StefanStore.Service;
using StefanStoreDTO.CartDto;
using StefanStoreDTO.ShippingDto;

namespace StefanStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;

        public CartController(CartDto cart, ICartService cartService)
        {
            _cartService = cartService;
        }

        public ViewResult ListCartItems(CartDto cart)
        {
            return View(cart);
        }

        public RedirectToRouteResult Back(CartDto cart)
        {
            return RedirectToAction("ListCartItems");
        }

        public RedirectToRouteResult AddProductToCart(CartDto cart, int productId)
        {
            var request = new CartServiceAddProductToCartRequest(cart, productId);

            _cartService.AddProductToCart(request);

            return RedirectToAction("ListCartItems");
        }

        public object FastDelivery(CartDto cart, bool isFastDelivery, string city)
        {
            city = "aaaaaaaa";

            var request = new CartServiceAddFastDeliveryRequest(cart, isFastDelivery);

            _cartService.AddFastDelivery(request);

            ViewBag.IsCheckOutLinkVisible = false;

            return Json(new { cartHtml = RenderRazorViewToString("Summary", cart), cityText = city }, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        private string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public RedirectToRouteResult RemoveProductFromCart(CartDto cart, int productId)
        {
            var request = new CartServiceRemoveProductToCartRequest(cart, productId);

            _cartService.RemoveProductFromCart(request);

            return RedirectToAction("ListCartItems");
        }

        public PartialViewResult Summary(CartDto cart, bool isCheckOutLinkVisible)
        {
            ViewBag.IsCheckOutLinkVisible = isCheckOutLinkVisible;
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetailsDto());
        }

        [HttpPost]
        public ViewResult Checkout(CartDto cart, ShippingDetailsDto shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}