using BLL.Interfaces;
using DAL.Entitys;
using DAL.enums;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Controllers
{
    [Authorize]
    public class UserManagerController : Controller
    {
        private readonly IUserBLL _userbll;
        public UserManagerController(IUserBLL userbll)
        {
            _userbll = userbll;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> GetAllList(SearchViewModel data)
        {
            var result = await _userbll.GetAllList(data);
            return Json(result);
        }

        [Authorize]
        public async Task<IActionResult> AddOrEdit(int id)
        {
            var user = await _userbll.GetUserById(id);
            return PartialView(user);
        }

        [Authorize]
        public async Task<IActionResult> Save(User user,string Email)
        {
            var username = HttpContext.Session.GetString("username");
            bool result = await _userbll.Save(user, username);
            if(username == Email && user.userstate == UserState.冻结)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return Json(new { msg = result ? "操作成功" : "操作失败，请刷新或检查账号是否已存在", code = result });
        }

        [Authorize]
        public async Task<IActionResult> DelUser(UserViewModel data)
        {
            var username = HttpContext.Session.GetString("username");
            bool result = await _userbll.DelUser(data, username);
            if (username == data.Email) await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Json(new { msg = result ? "删除成功" : "删除失败，请重试或刷新页面", code = result });
        }
    }
}
