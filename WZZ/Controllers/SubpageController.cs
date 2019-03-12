using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WZZ.Controllers
{
    public class SubpageController : Controller
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        private readonly IWZZModelBLL _modelBll;
        private readonly IArticleBLL _articleBll;
        public SubpageController(IWZZModelBLL modelbll, IArticleBLL articleBll)
        {
            _modelBll = modelbll;
            _articleBll = articleBll;
        }

        public IActionResult Index()
        {
            return PartialView();
        }

        /// <summary>
        /// 根据模块id得到该模块下的所有文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetModel(int id)
        {
            var modellist = _modelBll.GetModelByPid(id);
            var result = _articleBll.GetArticleByModel(modellist);
            return Json(result);
        }
    }
}