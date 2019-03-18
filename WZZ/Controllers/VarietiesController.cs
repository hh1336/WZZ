using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WZZ.Controllers
{
    public class VarietiesController : Controller
    {
        private readonly ITeaTypeBLL _teaType;
        private readonly IVarietiesBLL _bll;
        public VarietiesController(ITeaTypeBLL teaTypeBLL, IVarietiesBLL bll)
        {
            _teaType = teaTypeBLL;
            _bll = bll;
        }
        public IActionResult Index()
        {
            return PartialView();
        }

        public IActionResult GetTea(int id)
        {
            var result = _teaType.GetById(id);
            return Json(result);
        }

        public async Task<IActionResult> showArticle(int id)
        {
            var result = await _bll.GetAcById(id);
            return Json(result, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }
}