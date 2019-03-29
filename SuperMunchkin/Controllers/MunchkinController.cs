using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}