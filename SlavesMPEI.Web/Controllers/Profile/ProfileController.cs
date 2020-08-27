using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlavesMPEI.Domain.Repositories.Abstracts;
using SlavesMPEI.Web.Models.ViewModels;

namespace SlavesMPEI.Web.Controllers.Profile
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IOrder orderManager;

        public ProfileController(IOrder orderManager)
        {
            this.orderManager = orderManager;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return View(new ProfileViewModel(await orderManager.GetOrdersAsync()));
        }
    }
}