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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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
            if (result.code == 1)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,result.email)
            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                HttpContext.Session.SetString("username", result.email);
            }
            return Json(result);
        }

        [Authorize]
        public IActionResult OutLogin()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home/Index");
        }

    }
}
