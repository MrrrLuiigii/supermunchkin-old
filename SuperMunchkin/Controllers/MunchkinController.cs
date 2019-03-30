using Microsoft.AspNetCore.Mvc;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
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