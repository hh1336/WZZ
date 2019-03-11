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
    public class ModelManagerController : Controller
    {
        private readonly IWZZModelBLL _wzz;

        public ModelManagerController(IWZZModelBLL wzz)
        {
            this._wzz = wzz;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        
        public async Task<IActionResult> GetAllModal()
        {
            List<WZZModel> result = await _wzz.GetAllModal();
            return Json(result,new JsonSerializerSettings() {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        public async Task<IActionResult> AddOrEditModal(AddOrEditWZZModelViewModel modal)
        {
            WZZModel result = new WZZModel() { Pid = modal.pid };
            if (modal.id.HasValue && modal.id != 0) result = await _wzz.GetById(modal.id.Value);

            return PartialView(result);
        }

        public async Task<IActionResult> SaveModel(WZZModel data)
        {
            bool result = await _wzz.SaveModel(data);
            return Json(new { msg = result ? "保存成功" : "保存失败", code = result ? 1 : 2 });
        }
    }
}
