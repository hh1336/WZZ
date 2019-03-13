using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WZZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWZZModelBLL _WZZModelBLL;
        private readonly IRotationChartBLL _rotationChartBLL;

        public HomeController(IWZZModelBLL wZZModelBLL,IRotationChartBLL rotationChartBLL)
        {
            _WZZModelBLL = wZZModelBLL;
            _rotationChartBLL = rotationChartBLL;
        }

        //首页
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index_Article()
        {
            return View();
        }

        public async Task<IActionResult> GetModel(int id)
        {
            var result = await _WZZModelBLL.GetModelByMainModelId(id);
            return Json(result, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }
        //加载轮播图
        public IActionResult GetRotationCharts(int id)
        {
            var result = _rotationChartBLL.GetImgByModelId(id);
            return Json(result);
        }

    }
}