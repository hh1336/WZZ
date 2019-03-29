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
            var result = await _bll.Clear();
            #region 清空回收站的js
            //var index = Common.alert("提示", "慎重操作!所有回收站的数据将会被清除", function() {
            //    layer.close(index);
            //    var loadindex = layer.open({
            //    content: "系统操作中,请误刷新页面",
            //        type: 3
            //    });
            //    $.post("/Recovery/Clear", { }, function(result) {
            //        for (var i = 0; i < result.length; i++)
            //        {
            //            $.post("/Home/DelFile", { url: result[i] });
            //    }
            //    layer.close(loadindex);
            //    layer.msg("删除成功!", { icon: 1 });
            //    //刷新数据
            //    reload({
            //    field: _sortField,
            //            type: _sortType
            //        });

            //})
            //})
            #endregion
            return Json(result);
        }

    }
}
