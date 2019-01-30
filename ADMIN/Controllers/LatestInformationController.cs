using BLL.Interfaces;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Controllers
{
    [Authorize]
    public class LatestInformationController : Controller
    {
        private readonly IWZZModelBLL _wzzbll;
        public LatestInformationController(IWZZModelBLL wZZModelBLL)
        {
            _wzzbll = wZZModelBLL;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetList(SearchViewModel model)
        {

            return Json(new { Code = 200, Message = "加载成功", Total = 11, Result = 1 });
        }
    }
}
