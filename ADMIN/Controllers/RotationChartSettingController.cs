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
    public class RotationChartSettingController: Controller
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

        public async Task<IActionResult> GetList()
        {
            RotationChartViewModel result = await _bll.GetAll();
            return Json(result);
        }

        public async Task<IActionResult> AddOrEdit(RotationChartInputModel model)
        {
            RotationChart result = await _bll.GetById(model);
            return PartialView(result);
        }
    }
}
