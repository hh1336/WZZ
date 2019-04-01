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
using System.IO;
using System.Web;
using BLL.Commons;
using DAL.ViewModels;
using DAL.Entitys;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ADMIN.Controllers
{
    /// <summary>
    /// 特性注解，如果没有登陆则无法进入该控制器
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoginBLL _login;
        private readonly IWZZModelBLL _wzzmodel;
        private readonly IUserBLL _user;
        private readonly IVisitAmountBLL _visitamount;

        /// <summary>
        /// 通过构造函数注入需要使用到的BLL
        /// </summary>
        /// <param name="login"></param>
        /// <param name="wzzmodel"></param>
        /// <param name="user"></param>
        public HomeController(ILoginBLL login, IWZZModelBLL wzzmodel, IUserBLL user, IVisitAmountBLL visitAmountBLL)
        {
            _login = login;
            _wzzmodel = wzzmodel;
            _user = user;
            _visitamount = visitAmountBLL;
        }

        public IActionResult Index()
        {
            return View("Visitamount");
        }

        public async Task<IActionResult> UserInfo()
        {
            return View("Index");
        }

        /// <summary>
        /// 获取session中的值
        /// </summary>
        /// <param name="key">传入key，根据key来获取值</param>
        /// <returns></returns>
        public IActionResult GetSession(string key)
        {
            var value = HttpContext.Session.GetString(key);
            if (string.IsNullOrEmpty(value))
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("Index");
            }
            var result = _login.GetUserInfo(value);
            return Json(result);
        }

        /// <summary>
        /// 根据模块pid来获取子模块，如果pid为空，则表示获取最大的模块
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IActionResult GetModel(int? pid)
        {
            var result = _wzzmodel.GetModelByPid(pid);
            return Json(result);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public IActionResult UpdateInfo(User userInfo)
        {
            string url;
            var result = _user.Updata(userInfo, out url);
            if (result && !string.IsNullOrEmpty(url))
            {
                DelFile(url);
            }
            return Json(new { msg = result ? "修改成功" : "修改失败", url = "/Home/Index" });
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UpFile()
        {
            var files = Request.Form.Files;
            List<FileInfoViewModel> FileInfos = new List<FileInfoViewModel>();
            foreach (var item in files)
            {
                //文件名
                var name = DateTime.Now.Millisecond + item.FileName;
                //绝对路径路径
                string filepath = Path.GetFullPath("wwwroot/ImageFiles/" + name);
                //相对路径
                string repath = "/ImageFiles/" + name;

                //将图片拷贝到ImageFiles目录下
                FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                item.CopyTo(fs);
                fs.Close();

                FileInfos.Add(new FileInfoViewModel()
                {
                    FileName = name,
                    FilePath = repath
                });
            }
            return Json(FileInfos);
        }

        /// <summary>
        /// 删除文件的方法
        /// </summary>
        /// <param name="url">文件路径</param>
        /// <returns></returns>
        public bool DelFile(string url)
        {
            if (System.IO.File.Exists(Path.GetFullPath("wwwroot" + url)))
            {
                System.IO.File.Delete(Path.GetFullPath("wwwroot" + url));
                return true;
            }
            return false;

        }

        /// <summary>
        /// 设置session的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public IActionResult SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            return Ok();
        }

        /// <summary>
        /// 根据session的key获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IActionResult GetSessionValue(string key)
        {
            var value = HttpContext.Session.GetString(key);
            return Json(value);
        }

        /// <summary>
        /// 检索浏览量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetVisitamount(VisitAmountInputViewModel data)
        {
            var result = await _visitamount.GetVisiByTime(data);

            return Json(result);
        }

        /// <summary>
        /// 加载方块中最新数据
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LoadNewData()
        {
            var result = await _visitamount.LoadNewData();
            return Json(result);
        }

    }
}
