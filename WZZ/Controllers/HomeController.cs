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
        private readonly IWebStationSettingBLL _webbll;
        private readonly IArticleBLL _article;

        public HomeController(IWZZModelBLL wZZModelBLL, IRotationChartBLL rotationChartBLL, IWebStationSettingBLL webbll,IArticleBLL article)
        {
            _WZZModelBLL = wZZModelBLL;
            _rotationChartBLL = rotationChartBLL;
            _webbll = webbll;
            _article = article;
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
            return Json(result, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
        //加载轮播图
        public IActionResult GetRotationCharts(int id)
        {
            var result = _rotationChartBLL.GetImgByModelId(id);
            return Json(result);
        }

        //加载网站信息
        public async Task<IActionResult> GetWebInfo(int id)
        {
            var result = await _webbll.GetInfoById(id);
            return Json(result);
        }

        /// <summary>
        /// 根据模块id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetModelArc(int id)
        {
            var result = _article.GetArticleByModelId(id);
            return PartialView(result);
        }

        /// <summary>
        /// 查看文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SelectArticle(int id)
        {
            var acdata = await _article.GetAcByAcid(id);
            if (acdata.id == 0) return NotFound();
            return View("Index_Article", acdata);
        }

    }
}