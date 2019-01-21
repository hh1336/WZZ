using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMIN.Models;

namespace ADMIN.Controllers
{
    public class Admin_LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       

    }
}
