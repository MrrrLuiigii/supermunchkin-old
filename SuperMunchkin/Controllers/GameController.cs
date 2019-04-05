using Models;
using Microsoft.AspNetCore.Mvc;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index(int userId)
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}