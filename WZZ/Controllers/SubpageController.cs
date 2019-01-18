using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WZZ.Controllers
{
    public class SubpageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}