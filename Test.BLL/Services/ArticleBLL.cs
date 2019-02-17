using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Linq;
using System.Text;
using BLL.Commons;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// 文章服务实现
    /// </summary>
    public class ArticleBLL : IArticleBLL
    {
        private readonly MyDbContext _db;

        public ArticleBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 创建或修改文章表信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<int> AddOrUpdate(Article data)
        {
            if (data.id == 0)
            {//判断是0就为新增
                data.createTime = DateTime.Now;
                await _db.Articles.AddAsync(data);
                var result = await _db.SaveChangesAsync();
                if(result > 0)
                {
                    return data.id;
                }
                else
                {
                    return 0;
                }
            }
            else//不是0就为修改
            {
                var article = await _db.Articles.SingleOrDefaultAsync(a => a.id == data.id);
                if (article == null)
                {
                    //如果查不到数据则返回false
                    return 0;
                }
                article.title = data.title;
                article.TeaTypeId = data.TeaTypeId;
                article.source = data.source;
                article.imgurl = data.imgurl;
                article.author = data.author;
                article.updateTime = DateTime.Now;
                article.WZZModelId = data.WZZModelId;
                article.isShow = data.isShow;
                var result = await _db.SaveChangesAsync();
                if (result == 1)
                {
                    return article.id;
                }
                else
                {
                    return 0;
                }

            }
        }

        /// <summary>
        /// 返回所有文章
        /// </summary>
        /// <returns></returns>
        public IQueryable<Article> GetAll()
        {
            return _db.Articles.Where(a => a.id >= 0);
        }

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns>List</returns>
        public List<Article> GetAllList()
        {
            var reslut = GetAll();
            return reslut.ToList();
        }

        /// <summary>
        /// 根据模块获取文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回文章和模块信息</returns>
        public List<ModelArticle> GetArticleByModel(List<WZZModel> model)
        {
            List<ModelArticle> modellist = new List<ModelArticle>();
            //循环每一个模块
            foreach (var item in model)
            {
                //把每个模块下的文章查询出来
                var Articles = _db.Articles.Where(a => a.WZZModelId == item.id);
                //把每个模块信息和对应的文章都放在一个ModelArticle集合中
                modellist.Add(new ModelArticle() { WZZModel = item, Articles = Articles.OrderByDescending(s => s.createTime).ToList() });
            }
            return modellist;
        }

        /// <summary>
        /// 根据模块id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Article> GetArticleByModelId(int id)
        {
            return _db.Articles.Where(a => a.WZZModelId == id && a.isShow == 1);
        }

        /// <summary>
        /// 对数据进行分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IPageList<Article>> GetArticlePageList(SearchViewModel model)
        {
            var result = await GetArticleByModelId(model.ModelId).Sort(model.field, model.order).ToPageList(model.limit, model.page);
            return result;
        }

        /// <summary>
        /// 根据id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetById(int id)
        {
            return _db.Articles.SingleOrDefault(a => a.id == id);
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Show(int id)
        {
            var article = await _db.Articles.SingleOrDefaultAsync(a => a.id == id);
            if (article == null) return false;
            article.isShow = 1;
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SoftDel(int id)
        {
            var article = await _db.Articles.SingleOrDefaultAsync(a => a.id == id);
            if (article == null) return false;
            article.isShow = 0;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
