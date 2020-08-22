using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlavesMPEI.Infrastructure.Extenshions;
using SlavesMPEI.Web.Models.ViewModels;

namespace SlavesMPEI.Web.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager; //Менеджер пользователей
        private readonly SignInManager<IdentityUser> signInManager; //Менеджер входа

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Login

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Name, model.Password, model.IsPersistent, false); //Входим в систему
                if (result.Succeeded)
                {
                    return LocalRedirect(Url.GetUrlHelper(returnUrl)); //Переходим по returnUrl
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неправильный логин и (или) пароль"); //Добавляем ошибки в модель
                }
            }
            return View(model);
        }

        #endregion Login

        #region Register

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Name);   //Ищем пользователя по имени
                if (user is null)
                {
                    var result = await userManager.CreateAsync(new IdentityUser(model.Name), model.Password);   //Создаем пользователя
                    if (result.Succeeded)
                    {
                        await signInManager.PasswordSignInAsync(model.Name, model.Password, model.IsPersistent, false); //Входим в систему
                        return LocalRedirect(Url.GetUrlHelper(returnUrl));  //Перенаправляем по returnUrl
                    }
                    else
                    {
                        foreach (var error in result.Errors) //Добавляем ошибки в модель
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Логин занят"); //Добавляем ошибки в модель
                }
            }
            return View(model);
        }

        #endregion Register

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutAsync()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}