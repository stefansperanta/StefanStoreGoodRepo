using System.Web.Mvc;
using StefanStore.Service;

namespace StefanStore.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private INavigationService _navigationService;

        public NavigationController(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            return PartialView(_navigationService.BuildMenu());
        }
    }
}
