using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WZZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWZZModelBLL _WZZModelBLL;

        public HomeController(IWZZModelBLL wZZModelBLL)
        {
            _WZZModelBLL = wZZModelBLL;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetModel(int id)
        {
            var result = _WZZModelBLL.GetById(id);
            return Json(result);
        }


    }
}