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

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public IActionResult UpFile()
        {
            var files = Request.Form.Files;
            List<string> filename = new List<string>();
            foreach (var item in files)
            {
                //文件名
                var name = DateTime.Now.Millisecond + item.FileName;
                //保存路径
                string filepath = Path.GetFullPath("ImageFiles/" + name);

                //将图片拷贝到ImageFiles目录下
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    item.CopyToAsync(fs);
                }
                filename.Add(name);
            }
            return Json(filename);
        }
    }
}
