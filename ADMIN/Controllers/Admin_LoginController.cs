using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADMIN.Models;
using BLL.Interfaces;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ADMIN.Controllers
{
    public class Admin_LoginController : Controller
    {
        private readonly ILoginBLL bll;
        public Admin_LoginController(ILoginBLL login)
        {
            bll = login;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var result = bll.LoginUser(login.email, login.pwd);
            //http://www.cnblogs.com/wyt007/p/8128186.html
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,result.email)
            };

            return Json(result);
        }

    }
}
