using BLL.Interfaces;
using DAL.Entitys;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Controllers
{
    [Authorize]
    public class LatestInformationController : Controller
    {
        private readonly IWZZModelBLL _wzzbll;
        private readonly IArticleBLL _article;
        private readonly IArticleConTentBLL _articleConTent;
        private readonly IArticleImageBLL _articleImage;
        private readonly ISubheadingBLL _subheading;
        public LatestInformationController(IWZZModelBLL wZZModelBLL, IArticleBLL article, IArticleConTentBLL articleConTentBLL, IArticleImageBLL articleImageBLL, ISubheadingBLL subheading)
        {
            _wzzbll = wZZModelBLL;
            _article = article;
            _articleConTent = articleConTentBLL;
            _articleImage = articleImageBLL;
            _subheading = subheading;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList(SearchViewModel model)
        {
            var result = await _article.GetArticlePageList(model);
            return Json(result);
        }

        /// <summary>
        /// 创建或编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            return View();
        }


        /// <summary>
        /// 新增或修改文章表内容
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveArticleTitle(Article data)
        {
            var articleid = await _article.AddOrUpdate(data);
            return Json(new { code = articleid == 0 ? false : true, aid = articleid });
        }

        /// <summary>
        /// 新增或修改文章段落内容
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveArticleContent(ArticleConTent data)
        {
            int aid = await _articleConTent.AddOrUpdate(data);
            return Json(new { code = aid == 0 ? false : true, aid = aid });
        }

        /// <summary>
        /// 保存对应段落的图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveArticleImage(ArticleImage data)
        {
            int aid = await _articleImage.Add(data);
            return Json(new { code = aid == 0 ? false : true, aid = aid });
        }

        /// <summary>
        /// 保存文章图片的描述
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveArticleImgTitle(ArticleImage data)
        {
            bool result = await _articleImage.UpdateTitle(data);
            return Json(new { code = result });
        }

        /// <summary>
        /// 保存文章段落的标题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveSubheading(Subheading data)
        {
            int aid = await _subheading.AddOrUpdate(data);
            return Json(new { code = aid == 0 ? false : true, aid = aid });
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DelSubheading(int id)
        {
            bool result = await _subheading.Del(id);
            return Json(result);
        }

        /// <summary>
        /// 显示文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Show(int id)
        {
            bool result = await _article.Show(id);
            return Json(result);
        }

        public async Task<IActionResult> SoftDel(int id)
        {
            bool result = await _article.SoftDel(id);
            return Json(new { msg = result ? "删除成功" : "删除失败" });
        }

    }
}
