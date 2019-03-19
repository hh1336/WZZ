using BLL.Interfaces;
using DAL.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Controllers
{
    [Authorize]
    public class WebStationSettingController : Controller
    {
        private readonly IWebStationSettingBLL _bll;
        public WebStationSettingController(IWebStationSettingBLL bLL)
        {
            _bll = bLL;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetWebInfo(int id)
        {
            var result = await _bll.GetInfoById(id);
            return Json(result);
        }

        public async Task<IActionResult> Save(WebStationSetting data)
        {
            bool result = await _bll.Save(data);
            return Json(result);
        }
    }
}
