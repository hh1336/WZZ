using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WZZ.Controllers
{
    public class VarietiesController : Controller
    {
        private readonly ITeaTypeBLL _teaType;
        public VarietiesController(ITeaTypeBLL teaTypeBLL)
        {
            _teaType = teaTypeBLL;
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

        public IActionResult GetAllTeaType()
        {
            var result = _teaType.GetTeaTypeAndArticle();
            return Json(result);
        }
    }
}