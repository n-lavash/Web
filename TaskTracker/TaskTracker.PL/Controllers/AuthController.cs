using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskTracker.BLL.Interfaces;
using TaskTracker.WebApiPL.Models;

namespace TaskTracker.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private ITaskTrackerLogic _taskTrackerLogic;

        public AuthController(ILogger<AuthController> logger, ITaskTrackerLogic taskTrackerLogic)
        {
            _logger = logger;
            _taskTrackerLogic = taskTrackerLogic;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                if (IsValidAccountData(accountModel.Login, accountModel.Password))
                {
                    await Authenticate(accountModel.Login);

                    return RedirectToAction("GetUsersTask", "Home");
                }
                ModelState.AddModelError("", "Неверные логин или пароль.");
            }

            return View(accountModel);
        }

        [HttpGet]
        public IActionResult Registered()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registered(AccountModel account, UserModel user)
        {
            if (ModelState.IsValid)
            {
                var name = user.Name;
                var phoneNumber = user.PhoneNumber;
                var login = account.Login;
                var password = account.Password;

                if (name != null && phoneNumber != null && login != null && password != null)
                {
                    RegisterUser(name, phoneNumber, login, password);

                    await Authenticate(account.Login);
                    return RedirectToAction("GetUsersTask", "Home");
                }
                else
                    ModelState.AddModelError("", "Все поля должны быть заполнены.");
            }

            return View();

        }

        private bool IsValidAccountData(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;
            else if (_taskTrackerLogic.CheckAccount(login, password))
                return false;

            return true;
        }

        private void RegisterUser(string name, string phoneNumber, string login, string password)
        {
            _taskTrackerLogic.AddUser(name, login, password, phoneNumber);
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
