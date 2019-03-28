using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Entitys;
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
        private readonly IVisitAmountBLL _visit;

        public HomeController(
            IWZZModelBLL wZZModelBLL,
            IRotationChartBLL rotationChartBLL,
            IWebStationSettingBLL webbll,
            IArticleBLL article,
            IVisitAmountBLL visit)
        {
            _WZZModelBLL = wZZModelBLL;
            _rotationChartBLL = rotationChartBLL;
            _webbll = webbll;
            _article = article;
            _visit = visit;
        }

        //首页
        public async Task<IActionResult> Index()
        {
            await VisitUser();
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
            await VisitUser(id);
            return View("Index_Article", acdata);
        }


        /// <summary>
        /// 记录用户浏览
        /// </summary>
        /// <returns></returns>
        private async Task VisitUser(int? id = 0)
        {
            var userHostAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipaddress = userHostAddress.Substring(7);

            if (id.Value == 0)
            {
                //判断是否浏览过
                bool isNull = _visit.IsAddress(ipaddress);
                //如果浏览过
                if (isNull) return;
                await _visit.SaveAddress(new VisitAmount()
                {
                    ipaddress = userHostAddress,
                    visitDateTime = DateTime.Now
                });
                return;
            }
            else
            {
                //判断用户是否浏览过这篇文章
                bool isVisitAc = await _visit.IsVisitAc(userHostAddress, id.Value);
                if (isVisitAc) return;
                var visitinfo = new VisitAmount()
                {
                    ipaddress = userHostAddress,
                    visitDateTime = DateTime.Now,
                    ArticleId = id
                };
                await _visit.SaveAddress(visitinfo);
                return;
            }
        }

    }
}