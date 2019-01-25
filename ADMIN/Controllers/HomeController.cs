using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMIN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BLL.Interfaces;

namespace ADMIN.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoginBLL _login;
        private readonly IWZZModelBLL _wzzmodel;

        public HomeController(ILoginBLL login, IWZZModelBLL wzzmodel)
        {
            _login = login;
            _wzzmodel = wzzmodel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSession(string key)
        {
            var value = HttpContext.Session.GetString(key);
            var result = _login.GetUserInfo(value);
            return Json(result);
        }

        public IActionResult GetModel(int? pid)
        {
            var result = _wzzmodel.GetModelByPid(pid);
            return Json(result);
        }
    }
}
