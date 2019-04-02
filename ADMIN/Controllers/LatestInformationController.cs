using BLL.Interfaces;
using DAL.Entitys;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class LatestInformationController : Controller
    {
        #region 构造函数和依赖注入
        private readonly IWZZModelBLL _wzzbll;
        private readonly IArticleBLL _article;
        private readonly IArticleConTentBLL _articleConTent;
        private readonly IArticleImageBLL _articleImage;
        private readonly ISubheadingBLL _subheading;

        /// <summary>
        /// 通过构造函数进行依赖注入
        /// </summary>
        public LatestInformationController(IWZZModelBLL wZZModelBLL, IArticleBLL article, IArticleConTentBLL articleConTentBLL, IArticleImageBLL articleImageBLL, ISubheadingBLL subheading)
        {
            _wzzbll = wZZModelBLL;
            _article = article;
            _articleConTent = articleConTentBLL;
            _articleImage = articleImageBLL;
            _subheading = subheading;
        }
        #endregion

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
        /// 根据id获取模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetModelInfo(int id)
        {
            var result = await _wzzbll.GetById(id);
            return Json(result.name);
        }

        /// <summary>
        /// 创建或编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            if (id.HasValue)
            {
                var username = HttpContext.Session.GetString("username");
                var data = await _article.UserEditTheAc(id.Value,username);
                return View("Update", data);
            }
            return View();
        }

        /// <summary>
        /// 新增或修改文章表内容
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> SaveArticleTitle(Article data)
        {
            var username = HttpContext.Session.GetString("username");
            var articleid = await _article.AddOrUpdate(data,username);
            return Json(new { code = articleid == 0 ? false : true, aid = articleid });
        }

        /// <summary>
        /// 新增或修改文章段落内容
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Show(int id)
        {
            bool result = await _article.Show(id);
            return Json(result);
        }

        /// <summary>
        /// 执行软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> SoftDel(int id)
        {
            var username = HttpContext.Session.GetString("username");
            bool result = await _article.SoftDel(id,username);
            return Json(new { msg = result ? "删除成功" : "删除失败" });
        }

        /// <summary>
        /// 根据文章id获取文章的章节内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> LoadAcByAcId(int aid)
        {
            var result = await _article.GetAcByAcid(aid);
            //不允许循环序列化
            var setting = new JsonSerializerSettings();
            setting.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            return Json(result, setting);
        }

        /// <summary>
        /// 根据文章内容id加载图片
        /// </summary>
        /// <param name="actId"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> LoadImg(int actId)
        {
            //得到需要的图片
            List<ArticleImage> imgs = await _articleImage.FindByActId(actId);
            List<FileStream> files = new List<FileStream>();
            foreach (var item in imgs)
            {
                //得到路径去打开图片，添加到文件数组中
                var file = Path.GetFullPath("wwwroot" + item.url);
                files.Add(new FileStream(file, FileMode.Open));
            }
            return Json(new { imgs = files });
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> DelImg(int id)
        {
            bool result = await _articleImage.DelById(id);
            return Json(result);
        }
    }
}
