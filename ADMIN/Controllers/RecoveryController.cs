using Microsoft.AspNetCore.Authorization;
using BLL.Interfaces;
using DAL.Entitys;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Controllers
{
    [Authorize]
    public class RecoveryController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
