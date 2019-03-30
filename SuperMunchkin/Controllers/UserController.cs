using Microsoft.AspNetCore.Mvc;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Game");
            }

            return View(uvm);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                if(uvm.Password == uvm.PasswordCheck)
                {
                    return RedirectToAction("Login", "User");
                }
            }

            return View(uvm);
        }
    }
}