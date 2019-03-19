using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WZZ.Controllers
{
    public class StoryController : Controller
    {
        private readonly IArticleBLL _article;

        public StoryController(IArticleBLL article)
        {
            _article = article;
        }

        public IActionResult Index()
        {
            return PartialView();
        }

        public async Task<IActionResult> GetNewArticle()
        {
            var result = await _article.GetNewArticle();
            return Json(result);
        }
    }
}