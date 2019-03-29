using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Game");
            }

            return View(uvm);
        }
    }
}