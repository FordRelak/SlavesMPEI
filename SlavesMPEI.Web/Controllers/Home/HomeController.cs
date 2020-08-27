using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlavesMPEI.Domain.Entities;
using SlavesMPEI.Domain.Repositories.Abstracts;
using SlavesMPEI.Web.Models.ViewModels;

namespace SlavesMPEI.Web.Controllers.Home
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<User> userManager;
        private readonly IOrder orderManager;

        public HomeController(IWebHostEnvironment webHostEnvironment, UserManager<User> userManager, IOrder orderManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.orderManager = orderManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;
                if (model.Task != null || model.Image != null)
                {
                    var imagePath = string.Empty;
                    if (model.Image != null)
                        imagePath = await UploadFileAsync(model.UserName, model.Image);

                    var order = new Order()
                    {
                        DeadLine = model.DeadLine,
                        Id = Guid.NewGuid().ToString(),
                        ImagePath = imagePath,
                        ProgLang = model.ProgLang.ToString(),
                        Subject = model.Subject,
                        Task = model.Task,
                        UserId = (await userManager.FindByNameAsync(model.UserName)).Id
                    };

                    await orderManager.AddOrderAsync(order);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Выберите картинку или напишите задание");
                }
            }
            //if (model.DeadLine == default)
            //{
            //    ModelState.AddModelError("DeadLine", "Выберите дату дедлайна");
            //}
            return View(model);
        }

        private async Task<string> UploadFileAsync(string userName, IFormFile image)
        {
            var uniqueFileName = userName + "_" + Guid.NewGuid().ToString();
            var filePath = Path.Combine("wwwroot\\images", uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return filePath;
        }
    }
}