using Microsoft.AspNetCore.Authorization;
using BLL.Interfaces;
using DAL.Entitys;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Controllers
{
    [Authorize]
    public class RecoveryController : Controller
    {
        private readonly IRecoveryServiceBLL _bll;
        public RecoveryController(IRecoveryServiceBLL bLL)
        {
            _bll = bLL;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetList(SearchViewModel model)
        {
            var result = await _bll.GetAllToPage(model);
            //不允许循环序列化
            var setting = new JsonSerializerSettings();
            setting.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            return Json(result, setting);
        }

        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> BackData(int id)
        {
            bool bol = await _bll.BackData(id);
            return Json(new { code = bol });
        }

        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DelData(int id)
        {
            DelArticleResultModel result = await _bll.DelData(id);
            return Json(result);
        }

        /// <summary>
        /// 清空回收站
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Clear()
        {
            DelArticleResultModel result = await _bll.Clear();
            return Json(result);
        }

    }
}
