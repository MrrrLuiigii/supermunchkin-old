using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Mvc;
using Models;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
        private MunchkinLogic munchkinLogic = new MunchkinLogic();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MunchkinViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Game");
            }

            return View(mvm);
        }
    }
}