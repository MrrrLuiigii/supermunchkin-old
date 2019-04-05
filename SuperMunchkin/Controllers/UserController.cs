using Logic.Users;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class UserController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private UserCollectionLogic userCollectionLogic = new UserCollectionLogic();

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
                    User user = new User(uvm.Username, uvm.Password, uvm.Email);
                    
                    if (userCollectionLogic.AddUser(user))
                    {
                        return RedirectToAction("Login");
                        
                    }

                    ViewBag.ErrorMessage = "This username and\\or email has already been taken.";
                    return View();
                }
            }

            ViewBag.ErrorMessage = "All fields are required.";
            return View();
        }
    }
}