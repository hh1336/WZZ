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
        private readonly IArticleBLL _article;
        public LatestInformationController(IWZZModelBLL wZZModelBLL, IArticleBLL article)
        {
            _wzzbll = wZZModelBLL;
            _article = article;
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
        [HttpGet]
        public IActionResult GetList(SearchViewModel model)
        {
            var result = _article.GetArticlePageList(model);
            return Json(result);
        }
    }
}
