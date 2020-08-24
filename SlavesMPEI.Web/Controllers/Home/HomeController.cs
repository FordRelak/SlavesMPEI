using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlavesMPEI.Web.Models.ViewModels;

namespace SlavesMPEI.Web.Controllers.Home
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View(model);
        }
    }
}