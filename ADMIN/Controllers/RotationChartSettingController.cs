using BLL.Interfaces;
using DAL.Entitys;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class RotationChartSettingController : Controller
    {
        private readonly IRotationChartSettingBLL _bll;
        public RotationChartSettingController(IRotationChartSettingBLL bll)
        {
            _bll = bll;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetList(int? wzzid)
        {
            if (wzzid.HasValue)
            {
                var rolist = await _bll.GetAllByWzzId(wzzid.Value);

                return Json(rolist, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            }
            RotationChartViewModel result = await _bll.GetAll();
            return Json(result);
        }

        public async Task<IActionResult> AddOrEdit()
        {
            return PartialView();
        }

        public async Task<IActionResult> GetArticles()
        {
            List<Article> result = await _bll.GetArticles();
            return PartialView("ChoiceAc", result);
        }

        public async Task<IActionResult> AddRotationChart(List<RotationChart> data)
        {
            bool result = await _bll.AddRotationChart(data);
            return Json(result);
        }

        public async Task<IActionResult> RemovRotationChart(int id)
        {
            bool result = await _bll.DelRotationChart(id);
            return Json(result);
        }
    }
}
